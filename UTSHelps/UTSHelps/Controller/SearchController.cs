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

namespace UTSHelps.Controller
{
	public class SearchController : BaseController
	{
		public MainData HelpsData {get; set;}
		public Page parentView { get; set;}

		public SearchController () : base (new SearchView())
		{
			
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
			List <Workshop> workshops = await SearchKeywordsInModel (text);

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

		public void OnDoneInput(string text)
		{

		}

		public async Task<List<Workshop>> SearchKeywordsInModel(string keyword)
		{
			List <Workshop> results = new List<Workshop> ();

			return await Task.Run (() => {

				if (HelpsData != null)
				{
					List <double>Similarities = new List<double>();

					foreach (WorkshopSet workshopSet in HelpsData.WorkShopsData.Sets)
					{
						if (workshopSet.SetWorkshops != null) 
						{

							foreach (Workshop shop in workshopSet.SetWorkshops.workshops)
							{
								results.Add(shop);
								Similarities.Add(CalculateSimilarity(keyword, shop.topic));
							}
						}
					}

					for (int i = 0; i < Similarities.Count; i++)
					{
						for (int j = 0; j < Similarities.Count - 1; j++)
						{
							if (Similarities[j] < Similarities[j + 1])
							{
								double temp1 = Similarities[j];
								Similarities[j] = Similarities[j + 1];
								Similarities[j + 1] = temp1;

								Workshop temp2 = results[j];
								results[j] = results[j + 1];
								results[j + 1] = temp2;
							}
						}
					}
				}

				return results;
			});
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

