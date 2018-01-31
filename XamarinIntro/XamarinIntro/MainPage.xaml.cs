using Microsoft.ProjectOxford.Emotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinIntro
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        public async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            IsBusy = true;
            actIndicator.IsVisible = true;
            actIndicator.IsRunning = true;

            var clientEmotions =
               new EmotionServiceClient("ec52f8569cb44102be23afbb5f02b30e");

            var emotions = await
                clientEmotions.RecognizeAsync(((Client)e.Item).PhotoUrl.ToString());

            var emotion = emotions.First().Scores.ToRankedList().First();

            await DisplayAlert("Resultados", $"Emoción {emotion.Key} Valor {emotion.Value}", "Ok");

            actIndicator.IsVisible = false;
            actIndicator.IsRunning = false;
        }

        public async void Handle_Clicked(object sender, EventArgs e)
        {
            lvClients.ItemsSource = await ApiClients.GetClients();
        }
    }
}
