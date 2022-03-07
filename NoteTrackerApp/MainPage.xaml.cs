using NoteTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteTrackerApp
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
          var notes = new List<Note>();
          var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.notes.txt");

            foreach(var fileName in files)
            {
                var note = new Note
                {
                    Text = File.ReadAllText(fileName),
                    Date = File.GetCreationTime(fileName),
                    FileName = fileName
                };
                notes.Add(note);
            }
            NotesListView.ItemsSource = notes.OrderByDescending(n => n.Date);
        }
        private async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddNotePage
            {


                BindingContext = new Note()

            });
        }

        private async void NotesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new AddNotePage
            {


                BindingContext = (Note)e.SelectedItem

            });
        }
    }
}
