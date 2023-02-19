using FootballManagement_UWPClient.Data;
using FootballManagement_UWPClient.Models;
using FootballManagement_UWPClient.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FootballManagement_UWPClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly ITeamRepository teamRepository;
        private readonly ILeagueRepository leagueRepository;
        public MainPage()
        {
            this.InitializeComponent();
            teamRepository = new TeamRepository();
            leagueRepository = new LeagueRepository();
            FillDropDown();
        }
        private async void FillDropDown()
        {
            //Show Progress
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            try
            {
                List<League> leagues = await leagueRepository.GetLeagues();
                //Add the All Option
                leagues.Insert(0, new League { Code = null, Name = " - All Leagues" });
                //Bind to the ComboBox
                LeagueCombo.ItemsSource = leagues;
                btnAdd.IsEnabled = true;
                ShowTeams(null);
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("connection with the server"))
                {
                    Jeeves.ShowMessage("Error", "No connection with the server.");
                }
                else
                {
                    Jeeves.ShowMessage("Error", "Could not complete operation");
                }
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }
        private async void ShowTeams(string LeagueCode = null)
        {
            //Show Progress
            progRing.IsActive = true;
            progRing.Visibility = Visibility.Visible;

            try
            {
                List<Team> teams;
                if (LeagueCode == null)
                {
                    teams = await teamRepository.GetTeams();
                    
                }
                else
                {
                    teams = await teamRepository.GetTeamByLeague(LeagueCode);
                }
                teamList.ItemsSource = teams;

            
                
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("connection with the server"))
                {
                    Jeeves.ShowMessage("Error", "No connection with the server.");
                }
                else
                {
                    Jeeves.ShowMessage("Error", "Could not complete operation");
                }
            }
            finally
            {
                progRing.IsActive = false;
                progRing.Visibility = Visibility.Collapsed;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            FillDropDown();
        }

        private void LeagueCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            League selLea = (League)LeagueCombo.SelectedItem;
            ShowTeams(selLea?.Code);
        }

        private void teamGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Navigate to the detail page
            Frame.Navigate(typeof(TeamDetailPage), (Team)e.ClickedItem);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Team newTeam = new Team();
            newTeam.Budget= 600;

            // Navigate to the detail page
            Frame.Navigate(typeof(TeamDetailPage), newTeam);
        }
    }
}
