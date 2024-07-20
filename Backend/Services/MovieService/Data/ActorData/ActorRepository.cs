using MovieService.Models;

namespace MovieService.Data.ActorData
{
    public class ActorRepository : IActorRepository
    {
        private readonly MovieDbContext _context;
        public ActorRepository(MovieDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Actor> GetAll()
        {
            IEnumerable<Actor> actors = _context.Actor.ToList();
            return actors;
        }

        public Actor GetById(int id)
        {
            Actor actor = _context.Actor.FirstOrDefault(x => x.Id == id);
            return actor;
        }

        public void InsertActor(Actor actor)
        {
            _context.Actor.Add(actor);

        }

        public void Update(int id, Actor actor)
        {
            Actor currentActor =  _context.Actor.FirstOrDefault(x => x.Id == id);
            if (currentActor != null)
            {
                currentActor.Name = actor.Name;
                currentActor.Description = actor.Description;
                currentActor.Img = actor.Img;

                _context.SaveChanges();
            }
        }
        public bool saveChange()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Actor> searchByName(string name)
        {
            return _context.Actor.Where(n => n.Name.Contains(name)).ToList();
        }
    }
}
