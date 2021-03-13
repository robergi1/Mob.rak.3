using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;

namespace XamCam
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            this.Title = "Meie vägev kaamera";
        }

        private async void BtnCam_Clicked(object sender, EventArgs e)
        {
            try
            {
                
                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });
                
                if (photo != null)
                    imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {

        }


    }
}
