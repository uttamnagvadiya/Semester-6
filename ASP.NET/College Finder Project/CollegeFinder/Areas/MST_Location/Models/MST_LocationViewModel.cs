namespace CollegeFinder.Areas.MST_Location.Models
{
    public class MST_LocationViewModel
    {
        public IEnumerable<LOC_CountryModel> CountryModelsList { get; set; }

        public LOC_CountryModel CountryModel { get; set; }

        public IEnumerable<LOC_StateModel> StateModelsList { get; set; }

        public LOC_StateModel StateModel { get; set; }

        public IEnumerable<LOC_CityModel> CityModelsList { get; set; }

        public LOC_CityModel CityModel { get; set; }
    }
}
