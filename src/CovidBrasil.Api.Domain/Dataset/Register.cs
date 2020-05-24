using System;

namespace CovidBrasil.Api.Domain.Dataset
{
    public class Register
    {
        public Guid DatasetId { get; private set; }
        public String Region { get; private set; }
        public String State { get; private set; }
        public int RegionId { get; private set; }
        public int CityId { get; set; }
        public int HealthAreaId { get; private set; }
        public string HealthAreaName { get; private set; }
        public DateTime OcurrenceDate { get; private set; }
        public int WeekNumEpi { get; private set; }
        public double Population { get; private set; }
        public int AccumulatedCases { get; private set; }
        public int AccumulatedDeaths { get; private set; }
        public int RecoveredCases { get; private set; }
        public int UnderObservationCases { get; private set; }

        public Register(string region, string state,
        int regionId, int cityId, int healthAredId, string healthAreaName,
        DateTime ocurrenceDate, int weekNumEpi, double population,
        int accumulatedCases, int accumulatedDeaths, int recoveredCases,
        int underObservationCases)
        {
            Region = region;
            State = state;
            RegionId = regionId;
            CityId = cityId;
            HealthAreaId = healthAredId;
            HealthAreaName = healthAreaName;
            OcurrenceDate = ocurrenceDate;
            WeekNumEpi = weekNumEpi;
            Population = population;
            AccumulatedCases = accumulatedCases;
            AccumulatedDeaths = accumulatedDeaths;
            RecoveredCases = recoveredCases;
            UnderObservationCases = underObservationCases;
        }
    }
}