using MovieService.Models;

namespace MovieService.Data.ActorData
{
    public interface IActorRepository
    {
        IEnumerable<Actor> GetAll();
        Actor GetById(int id);
        void InsertActor(Actor movie);
        void Update(int id, Actor movie);
        IEnumerable<Actor> searchByName(string name);
        bool saveChange();
    }
}
