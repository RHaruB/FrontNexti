using FrontNexti.ViewModels;

namespace FrontNexti.Services
{
    public interface IEvento
    {
        public  Task<List<EventoVM>> GetAllEventos();
    }
}
