using CommunityToolkit.Mvvm.ComponentModel;
using F1.Models;
using F1.Services.Ergast;
using F1.ViewMoldels.Base;
using F1.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1.ViewMoldels
{
    [ObservableObject]
    public partial class HomeViewModel
    {
        #region Fields

        private readonly IErgastService _ergastService;

        [ObservableProperty]
        private RaceEventModel _latestRaceObject;

        #endregion

        #region Properties

        public Task Init { get; }

        [ObservableProperty]
        public string latestRace;

        [ObservableProperty]
        public ObservableCollection<RaceResultModel> latestResults;
        public ObservableCollection<RaceEventModel> UpcomingRaceEventList { get; set; }
        public ObservableCollection<DriverStadingsModel> DriversList { get; set; }
        public ObservableCollection<ConstructorStadingsModel> TeamsList { get; set; }

        [ObservableProperty]
        public bool visitor = false;
   

        #endregion

        #region Commands

        public Command ProfileCommand { get; set; }
        public Command SeeDriverCommand { get; set; }
        public Command SeeMoreResultsCommand { get; set; }
        public Command SeeEventCommand { get; set; }
        public Command SeeMoreScheduleCommand { get; set; }
        public Command SeeDriversCommand { get; set; }
        public Command SeeTeamsCommand { get; set; }
        public Command DriverDetailsCommand { get; set; }
        public Command TeamDetailsCommand { get; set; }

        #endregion

        #region Constructors

        public HomeViewModel(
            IErgastService ergastService)
        {
           
            _ergastService = ergastService;



            ProfileCommand = new Command(ProfileCommandHandler);
            SeeDriverCommand = new Command<RaceResultModel>(SeeDriverCommandHandler);
            SeeMoreResultsCommand = new Command(SeeMoreResultsCommandHandler);
            SeeEventCommand = new Command<RaceEventModel>(SeeEventCommandHandler);
            SeeMoreScheduleCommand = new Command(SeeMoreScheduleCommandHandler);
            SeeDriversCommand = new Command(SeeDriversCommandHandler);
            SeeTeamsCommand = new Command(SeeTeamsCommandHandler);
            DriverDetailsCommand = new Command<DriverStadingsModel>(DriverDetailsCommandHandler);
            TeamDetailsCommand = new Command<ConstructorStadingsModel>(TeamDetailsCommandHandler);

            Init = Initialize();
        }

        #endregion

        #region Command Handlers

        private async void ProfileCommandHandler()
        {
            await Shell.Current.GoToAsync($"profile");
        }

        private async void SeeDriverCommandHandler(RaceResultModel raceResult)
        {
            var driver = new DriverStadingsModel()
            {
                Driver = raceResult.Driver,
                Constructors = new List<ConstructorModel>() { raceResult.Constructor }
            };
            await Shell.Current.GoToAsync($"//main/drivers/details?driver={driver.Driver.DriverId}");
        }

        private async void SeeMoreResultsCommandHandler()
        {
            await Shell.Current.GoToAsync($"//main/schedule/details?round={_latestRaceObject.Round}&selectedTab=1");
        }

        private async void SeeEventCommandHandler(RaceEventModel raceEvent)
        {
            await Shell.Current.GoToAsync($"//main/schedule/details?round={raceEvent.Round}");
        }

        private async void SeeMoreScheduleCommandHandler()
        {
            await Shell.Current.GoToAsync($"//main/schedule");
        }

        private async void SeeDriversCommandHandler()
        {
            await Shell.Current.GoToAsync($"//main/drivers");
        }

        private async void SeeTeamsCommandHandler()
        {
            await Shell.Current.GoToAsync($"//main/teams");
        }

        private async void DriverDetailsCommandHandler(DriverStadingsModel driver)
        {
            await Shell.Current.GoToAsync($"//main/drivers/details?driver={driver.Driver.DriverId}");
        }

        private async void TeamDetailsCommandHandler(ConstructorStadingsModel team)
        {
            await Shell.Current.GoToAsync($"//main/teams/details?team={team.Constructor.ConstructorId}");
        }

        #endregion

        #region Private Functionality

        private async Task Initialize()
        {
            Visitor = true;
            await GetResults();
            //await GetSchedule();
            //await GetDriverStadings();
            //await GetTeamStadings();
        }

        private async Task GetResults()
        {
            var res = await _ergastService.GetResults("current", "last", "results", "limit=10");
            _latestRaceObject = res.First();
            LatestRace = $"Round {res.First().Round} - {res.First().Circuit.Location.Country} ({res.First().Circuit.CircuitName})";
            LatestResults = new ObservableCollection<RaceResultModel>(res.First().Results)
            {
                new RaceResultModel()
            };

           Visitor = false;
        }

        private async Task GetSchedule()
        {
            var res = await _ergastService.GetSchedule("current");
            _latestRaceObject = res.PastRaceEvents.Last();
            UpcomingRaceEventList = new ObservableCollection<RaceEventModel>(res.UpcomingRaceEvents.Take(3))
            {
                new RaceEventModel()
            };
        }

        private async Task GetDriverStadings()
        {
            var res = await _ergastService.GetDriverStadings("current", "&limit=3");
            DriversList = new ObservableCollection<DriverStadingsModel>(res);
        }

        private async Task GetTeamStadings()
        {
            var res = await _ergastService.GetTeamStadings("current", "&limit=3");
            TeamsList = new ObservableCollection<ConstructorStadingsModel>(res);
        }

        #endregion
    }

}
