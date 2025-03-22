using Microsoft.Data.SqlClient;
using MusicCRUD.DataAccess.Entity;
using MusicCRUD.Repository.Settings;
using System.Data;

namespace MusicCRUD.Repository.Services;

public class MusicRepositoryAdoNet : IMusicRepository
{
    private readonly string ConnectionString;

    public MusicRepositoryAdoNet(SqlDBConeectionString sqlDBConeectionString)
    {
        ConnectionString = sqlDBConeectionString.ConnectionString; 
    }

    public async Task<long> AddMusicAsync(Music music)
    {
        // Call SP 

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand("sp_AddMusic", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", music.Name);
                cmd.Parameters.AddWithValue("@MB", music.MB);
                cmd.Parameters.AddWithValue("@AuthorName", music.AuthorName);
                cmd.Parameters.AddWithValue("@Description", music.Description);
                cmd.Parameters.AddWithValue("@QuentityLikes", music.QuentityLikes);

                SqlParameter outputId = new SqlParameter("@MusicId", SqlDbType.BigInt)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputId);

                await cmd.ExecuteNonQueryAsync();
                return Convert.ToInt64(outputId.Value);
            }
        }




        // With Query
        //var sql = @"
        //        INSERT INTO Music (Name, MB, AuthorName, Description, QuentityLikes) 
        //        OUTPUT INSERTED.MusicId
        //        VALUES (@Name, @MB, @AuthorName, @Description, @QuentityLikes);";

        //using (var conn = new SqlConnection(ConnectionString))
        //{
        //    await conn.OpenAsync();
        //    using (var cmd = new SqlCommand(sql, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@Name", music.Name);
        //        cmd.Parameters.AddWithValue("@MB", music.MB);
        //        cmd.Parameters.AddWithValue("@AuthorName", music.AuthorName);
        //        cmd.Parameters.AddWithValue("@Description", music.Description);
        //        cmd.Parameters.AddWithValue("@QuentityLikes", music.QuentityLikes);

        //        var res = (long)await cmd.ExecuteScalarAsync(); // Returns the new ID

        //        await conn.CloseAsync();
        //        return res;
        //    }
        //}
    }

    public async Task DeleteMusicAsync(long id)
    {
        string sql = "DELETE FROM Music WHERE MusicId = @Id;";

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }


    public async Task<List<Music>> GetAllMusicAsync()
    {
        // Work with SP

        List<Music> musicList = new List<Music>();

        using (SqlConnection conn = new SqlConnection(ConnectionString))
        {
            await conn.OpenAsync();
            using (SqlCommand cmd = new SqlCommand("sp_GetAllMusic", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        musicList.Add(new Music
                        {
                            MusicId = reader.GetInt64(0),
                            Name = reader.GetString(1),
                            MB = reader.GetDouble(2),
                            AuthorName = reader.GetString(3),
                            Description = reader.GetString(4),
                            QuentityLikes = reader.GetInt32(5)
                        });
                    }
                }
            }
        }
        return musicList;




        // Work with sql query
        //string sql = "SELECT MusicId, Name, MB, AuthorName, Description, QuentityLikes FROM Music;";
        //List<Music> musicList = new List<Music>();

        //using (SqlConnection conn = new SqlConnection(ConnectionString))
        //{
        //    await conn.OpenAsync();
        //    using (SqlCommand cmd = new SqlCommand(sql, conn))
        //    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            musicList.Add(new Music
        //            {
        //                MusicId = reader.GetInt64(0),
        //                Name = reader.GetString(1),
        //                MB = reader.GetDouble(2),
        //                AuthorName = reader.GetString(3),
        //                Description = reader.GetString(4),
        //                QuentityLikes = reader.GetInt32(5)
        //            });
        //        }
        //    }
        //}
        //return musicList;
    }

    public Task<Music> GetMusicByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMusicAsync(Music music)
    {
        throw new NotImplementedException();
    }
}
