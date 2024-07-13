using TheaterService.Models;

namespace TheaterService.Data
{
    public interface ITheaterRepo
    {
        IEnumerable<TheaterModel> getAllTheaters();
        TheaterModel getTheaterById(int id);
        void createTheater(TheaterModel theater);
        bool saveChange();

    }
}
