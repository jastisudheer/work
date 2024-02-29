using prac.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
    Task<Appointment> GetAppointmentByIdAsync(int id);
    Task<bool> CreateAppointmentAsync(Appointment appointment);
    Task<bool> UpdateAppointmentAsync(Appointment appointment);
    Task<bool> DeleteAppointmentAsync(int id);
    Task CreateAppointmentAsync(Appointment appointment);
}