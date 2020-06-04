using Moq;
using whitewaterfinder.Repo.Weather;
using whitewaterfinder.Core.Weather;
using System.Collections.Generic;
using whitewaterfinder.BusinessObjects.Weather;

namespace whitewaterfinder.test.WeatherServiceTests
{
    public abstract class BaseWeatherServiceTest
    {
        protected Mock<IForecastRepository> Repo;

        protected WeatherService sut;

        protected IEnumerable<NWSStation> ObservationStations
        {
            get
            {

                return new List<NWSStation>
                {
                    new NWSStation
                    {
                        Geometry = new NWSGeometry
                        {
                            Coordinates =  new double[]{ -82.9333, 39.81667 }
                        },
                        Properties = new NWSStationProperties 
                        {
                            StationIdentifier = "KLCK"
                        }
                    },
                    new NWSStation
                    {
                        Geometry = new NWSGeometry
                        {
                            Coordinates = new double[]{ -84.41583, 39.105829}
                        },
                        Properties = new NWSStationProperties
                        {
                            StationIdentifier = "KLUK"
                        }
                    }                
                };
            }
        }   

        protected NWSLocation NWSOffice
        {
            get
            {
                return new NWSLocation
                {
                    CWA = "ILN",
                    GridX = "88", 
                    GridY = "76"
                };
            }
        }       
        public BaseWeatherServiceTest()
        {
            Repo = new Mock<IForecastRepository>();

            sut = new WeatherService(Repo.Object);
        }
    }  

}