
using prac.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class AppointmentRepo : IAppointmentRepo
{
    private readonly string _connectionString;

    public AppointmentRepo(string connectionString)
    {
        _connectionString =  "Data Source=APINP-ELPTLZ7WJ\\SQLEXPRESS;Initial Catalog=HealthCareDb;User ID=tap2023;Password=tap2023;Encrypt=False";
    }

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
    {
        var appointments = new List<Appointment>();

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT * FROM appointment", connection);

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    appointments.Add(new Appointment
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        AppointmentTime = TimeSpan.Parse(reader["AppointmentTime"].ToString()),
                        Description = reader["Description"].ToString()
                    });
                }
            }
        }

        return appointments;
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id)
    {
        Appointment appointment = null;

        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("SELECT * FROM appointment WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            using (var reader = await command.ExecuteReaderAsync())
            {
                if (await reader.ReadAsync())
                {
                    appointment = new Appointment
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                        AppointmentTime = TimeSpan.Parse(reader["AppointmentTime"].ToString()),
                        Description = reader["Description"].ToString()
                    };
                }
            }
        }

        return appointment;
    }

    public async Task<bool> CreateAppointmentAsync(Appointment appointment)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("INSERT INTO appointment (PatientId, AppointmentDate, AppointmentTime, Description) VALUES (@PatientId, @AppointmentDate, @AppointmentTime, @Description)", connection);

            command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
            command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
            command.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime.ToString());
            command.Parameters.AddWithValue("@Description", appointment.Description);

            var result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }
    }

    public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("UPDATE appointment SET PatientId = @PatientId, AppointmentDate = @AppointmentDate, AppointmentTime = @AppointmentTime, Description = @Description WHERE Id = @Id", connection);

            command.Parameters.AddWithValue("@Id", appointment.Id);
            command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
            command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
            command.Parameters.AddWithValue("@AppointmentTime", appointment.AppointmentTime.ToString());
            command.Parameters.AddWithValue("@Description", appointment.Description);

            var result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var command = new SqlCommand("DELETE FROM appointment WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            var result = await command.ExecuteNonQueryAsync();
            return result > 0;
        }
    }

    public Task<bool> InsertAppointmentAsync(Appointment appointment)
    {
        throw new NotImplementedException();
    }
}