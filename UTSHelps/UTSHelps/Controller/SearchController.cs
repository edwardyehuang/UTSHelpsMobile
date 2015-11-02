using System;
using Xamarin.Forms;
using UTSHelps.Model;
using UTSHelps.View;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace UTSHelps.Controller
{
	public class SearchController : BaseController
	{
		public MainData HelpsData {get; set;}
		public Page parentView { get; set;}

		protected CancellationTokenSource source = new CancellationTokenSource ();

		public SearchController (MainData helpsData) : base (new SearchView())
		{
			HelpsData = helpsData;

			helpsData.BookingsData.UpdateData ();

			foreach (WorkshopSet workshopSet in HelpsData.WorkShopsData.Sets) {

				if (workshopSet.SetWorkshops == null) {
					string localData = App.Setting.GetSettingValue (Workshops.localKey + workshopSet.Id);

					if (localData != null) {
						if (!localData.Equals ("")) {
							workshopSet.SetWorkshops = new Workshops ();
							workshopSet.SetWorkshops.HelpsData = helpsData;
							workshopSet.SetWorkshops.RelatedWorkshopSet = workshopSet;
							workshopSet.SetWorkshops.DidReadResponse (localData);
						}
					}
				}
			}
		}

		public override void UpdateData ()
		{
			base.UpdateData ();



			((SearchView)View).SearchEntry.Focus ();
		}

		public override void RegViewEvents ()
		{
			base.RegViewEvents ();

			((SearchView)View).SearchEntry.TextChanged += (sender, e) => 
				OnTextChanged (((SearchView)View).SearchEntry.Text);

			((SearchView)View).SearchEntry.Completed += (sender, e) => 
				OnTextChanged (((SearchView)View).SearchEntry.Text);

			((SearchView)View).CloseBtn.Clicked += (object sender, EventArgs e) => View.Navigation.PopModalAsync(true);
		}

		public async void OnTextChanged(string text)
		{
			((SearchView)View).SuggestionListView.IsVisible = !text.Equals ("");
			((SearchView)View).TitleLabel.IsVisible = text.Equals ("");

			source.Cancel ();

			try
			{

				List <Workshop> workshops = await SearchKeywordsInModel (text, source.Token);

				TableSection section = new TableSection ();

				foreach (Workshop shop in workshops) {

					TextCell cell = new TextCell {
						Text = shop.topic,
					};

					cell.Tapped += (object sender, EventArgs e) => ShowSectionsInSessions (shop);
					section.Add (cell);
				}

				(((SearchView)View).SuggestionListView.Root = new TableRoot()).Add (section);
			}
			catch(Exception) {

			}
		}

		public void OnDoneInput(string text)
		{

		}

		public async Task<List<Workshop>> SearchKeywordsInModel(string keyword, CancellationToken ct)
		{
			List <Workshop> results = new List<Workshop> ();

			await Task.Run (() => {
				if (HelpsData != null) {
					List <double> Similarities = new List<double> ();

					foreach (WorkshopSet workshopSet in HelpsData.WorkShopsData.Sets) {


						if (workshopSet.SetWorkshops != null) {

							foreach (Workshop shop in workshopSet.SetWorkshops.workshops) {
								results.Add (shop);
								double topicSimilarity = CalculateSimilarity (keyword, shop.topic);
								double startDateSimilarity = CalculateSimilarity (keyword, shop.GetStartDate ().ToString ());
								double endDateSimilarity = CalculateSimilarity (keyword, shop.GetEndDate ().ToString ());
								double campus = CalculateSimilarity (keyword, shop.campus);

								Similarities.Add (topicSimilarity + startDateSimilarity + endDateSimilarity + campus);
							}
						}
					}

					for (int i = 0; i < Similarities.Count; i++) {
						for (int j = 0; j < Similarities.Count - 1; j++) {
							if (Similarities [j] < Similarities [j + 1]) {
								double temp1 = Similarities [j];
								Similarities [j] = Similarities [j + 1];
								Similarities [j + 1] = temp1;

								Workshop temp2 = results [j];
								results [j] = results [j + 1];
								results [j + 1] = temp2;
							}
						}
					}
				}
			});

			return results;

		}

		public void ShowSectionsInSessions(Workshop session)
		{
			//View.Navigation.PushAsync(new SessionsController(workShop.WorkShopSessions).View);
			View.Navigation.PopModalAsync(true);
			parentView.Navigation.PushAsync(new WorkshopController(session).View);
		}



		protected int ComputeLevenshteinDistance(string source, string target)
		{
			if ((source == null) || (target == null)) return 0;
			if ((source.Length == 0) || (target.Length == 0)) return 0;
			if (source == target) return source.Length;

			int sourceWordCount = source.Length;
			int targetWordCount = target.Length;

			// Step 1
			if (sourceWordCount == 0)
				return targetWordCount;

			if (targetWordCount == 0)
				return sourceWordCount;

			int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

			// Step 2
			for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++);
			for (int j = 0; j <= targetWordCount; distance[0, j] = j++);

			for (int i = 1; i <= sourceWordCount; i++)
			{
				for (int j = 1; j <= targetWordCount; j++)
				{
					// Step 3
					int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

					// Step 4
					distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
				}
			}

			return distance[sourceWordCount, targetWordCount];
		}

		protected double CalculateSimilarity(string source, string target)
		{
			if ((source == null) || (target == null)) return 0.0;
			if ((source.Length == 0) || (target.Length == 0)) return 0.0;
			if (source == target) return 1.0;

			int stepsToSame = ComputeLevenshteinDistance(source, target);
			return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
		}

	}
}

