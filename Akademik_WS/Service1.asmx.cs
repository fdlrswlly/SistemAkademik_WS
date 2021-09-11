using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;


namespace Akademik_WS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        SqlConnection sqlconn = new SqlConnection("Data Source = LAPTOP-VH6CET7D\\FADHLY;initial catalog = Db_akademik;integrated security = true");

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //Mahasiswa
        [WebMethod]
           public DataSet QueryModel(string nim)
           {
            SqlDataAdapter daObj = new SqlDataAdapter("Select * from tb_mahasiswa where nim = '" + nim + "'", sqlconn);
            DataSet dsObj = new DataSet();
            daObj.Fill(dsObj, "tb_mahasiswa");
            return dsObj;
           }
        [WebMethod]
        public void insertdata(string nim, string nama, string alamat, string jk, string email)
        {
            sqlconn.Open();
            SqlCommand sqlInsert = new SqlCommand("INSERT INTO tb_mahasiswa VALUES(@nim, @nama, @alamat, @jk, @email)", sqlconn);
            sqlInsert.Parameters.AddWithValue("@nim", nim);
            sqlInsert.Parameters.AddWithValue("@nama", nama);
            sqlInsert.Parameters.AddWithValue("@alamat", alamat);
            sqlInsert.Parameters.AddWithValue("@jk", jk);
            sqlInsert.Parameters.AddWithValue("@email", email);
            sqlInsert.ExecuteNonQuery();
            sqlconn.Close();

        }
        [WebMethod]
        public DataSet Display()
        {
            SqlDataAdapter sqlInsert = new SqlDataAdapter("SELECT * FROM tb_mahasiswa", sqlconn);
            DataSet ds = new DataSet();
            sqlInsert.Fill(ds, "tb_mahasiswa");
            return ds;
        }
        [WebMethod]
        public void DeleteAkademik(string nim)
        {
            sqlconn.Open();
            SqlCommand sqlDelete = new SqlCommand("Delete from tb_mahasiswa where nim = '" + nim + "'", sqlconn);
            sqlDelete.ExecuteNonQuery();
            sqlconn.Close();
        }
        [WebMethod]
        public void UbahAkademik(string nim, string nama, string alamat, string jk, string email)
        {
            sqlconn.Open();
            SqlCommand sqlUpdate = new SqlCommand("Update tb_mahasiswa set nama = '"+nama+"',alamat = '"+alamat+"',jenis_kelamin = '"+jk+"',email= '"+email+"' where nim = '"+nim+"'", sqlconn);
            sqlUpdate.ExecuteNonQuery();
            sqlconn.Close();
            
        }

        //Dosen
        [WebMethod]
        public DataSet DisplayDosen()
        {
            SqlDataAdapter sqlInsert = new SqlDataAdapter("SELECT * FROM tb_dosen", sqlconn);
            DataSet ds = new DataSet();
            sqlInsert.Fill(ds, "tb_dosen");
            return ds;
        }
        [WebMethod]
        public void InputDosen(string nip, string nama, string alamat, string email, string jk)
        {
            sqlconn.Open();
            SqlCommand sqlInsert = new SqlCommand("INSERT INTO tb_dosen VALUES(@nip, @nama, @alamat, @email, @jk)", sqlconn);
            sqlInsert.Parameters.AddWithValue("@nip", nip);
            sqlInsert.Parameters.AddWithValue("@nama", nama);
            sqlInsert.Parameters.AddWithValue("@alamat", alamat);
            sqlInsert.Parameters.AddWithValue("@email", email);
            sqlInsert.Parameters.AddWithValue("@jk", jk);
            sqlInsert.ExecuteNonQuery();
            sqlconn.Close();

        }
        [WebMethod]
        public DataSet QueryModelDosen(string nip)
        {
            SqlDataAdapter daObj = new SqlDataAdapter("Select * from tb_dosen where nip = '" + nip + "'", sqlconn);
            DataSet dsObj = new DataSet();
            daObj.Fill(dsObj, "tb_dosen");
            return dsObj;
        }
        [WebMethod]
        public void UbahDosen(string nip, string nama, string alamat, string email, string jk)
        {
            sqlconn.Open();
            SqlCommand sqlUpdate = new SqlCommand("Update tb_dosen set nama = '" + nama + "',alamat = '" + alamat + "',jenis_kelamin = '" + jk + "',email= '" + email + "' where nip = '" + nip + "'", sqlconn);
            sqlUpdate.ExecuteNonQuery();
            sqlconn.Close();
        }
        [WebMethod]
        public void HapusDosen(string nip)
        {
            sqlconn.Open();
            SqlCommand sqlDelete = new SqlCommand("Delete from tb_dosen where nip = '" + nip + "'", sqlconn);
            sqlDelete.ExecuteNonQuery();
            sqlconn.Close();
        }

        //Matkul
        [WebMethod]
        public DataSet DisplayMatkul()
        {
            SqlDataAdapter sqlInsert = new SqlDataAdapter("SELECT * FROM tb_matkul", sqlconn);
            DataSet ds = new DataSet();
            sqlInsert.Fill(ds, "tb_matkul");
            return ds;
        }
        [WebMethod]
        public void InputMatkul(string id_matkul, string nama_matkul, string sks, string nip)
        {
            sqlconn.Open();
            SqlCommand sqlInsert = new SqlCommand("INSERT INTO tb_matkul VALUES(@id_matkul, @nama_matkul, @sks, @nip)", sqlconn);
            sqlInsert.Parameters.AddWithValue("@id_matkul", id_matkul);
            sqlInsert.Parameters.AddWithValue("@nama_matkul", nama_matkul);
            sqlInsert.Parameters.AddWithValue("@sks", sks);
            sqlInsert.Parameters.AddWithValue("@nip", nip);
            sqlInsert.ExecuteNonQuery();
            sqlconn.Close();
        }
        [WebMethod]
        public DataSet QueryModelMatkul(string id_matkul)
        {
            SqlDataAdapter daObj = new SqlDataAdapter("Select * from tb_matkul where id_matkul = '" + id_matkul + "'", sqlconn);
            DataSet dsObj = new DataSet();
            daObj.Fill(dsObj, "tb_matkul");
            return dsObj;
        }
        [WebMethod]
        public void UbahMatkul(string id_matkul, string nama_matkul, string sks, string nip)
        {
            sqlconn.Open();
            SqlCommand sqlUpdate = new SqlCommand("Update tb_matkul set nama_matkul = '" + nama_matkul + "',sks = '" + sks + "',nip = '" + nip + "' where id_matkul = '" + id_matkul + "'", sqlconn);
            sqlUpdate.ExecuteNonQuery();
            sqlconn.Close();
        }
        [WebMethod]
        public void HapusMatkul(string id_matkul)
        {
            sqlconn.Open();
            SqlCommand sqlDelete = new SqlCommand("Delete from tb_matkul where id_matkul = '" + id_matkul + "'", sqlconn);
            sqlDelete.ExecuteNonQuery();
            sqlconn.Close();
        }

        //Nilai

        [WebMethod]
        public DataSet DisplayNilai()
        {
            SqlDataAdapter sqlInsert = new SqlDataAdapter("SELECT * FROM tb_nilai", sqlconn);
            DataSet ds = new DataSet();
            sqlInsert.Fill(ds, "tb_nilai");
            return ds;
        }
        [WebMethod]
        public void InputNilai(string id_nilai , string nim, string id_matkul, string nilai)
        {
            sqlconn.Open();
            SqlCommand sqlInsert = new SqlCommand("INSERT INTO tb_nilai VALUES(@id_nilai, @nim, @id_matkul, @nilai)", sqlconn);
            sqlInsert.Parameters.AddWithValue("@id_nilai", id_nilai);
            sqlInsert.Parameters.AddWithValue("@nim", nim);
            sqlInsert.Parameters.AddWithValue("@id_matkul", id_matkul);
            sqlInsert.Parameters.AddWithValue("@nilai", nilai);
            sqlInsert.ExecuteNonQuery();
            sqlconn.Close();
        }
        [WebMethod]
        public DataSet QueryModelNilai(string id_nilai)
        {
            SqlDataAdapter daObj = new SqlDataAdapter("Select * from tb_nilai where id_nilai = '" + id_nilai + "'", sqlconn);
            DataSet dsObj = new DataSet();
            daObj.Fill(dsObj, "tb_nilai");
            return dsObj;
        }
        [WebMethod]
        public void UbahNilai(string id_nilai, string nim, string id_matkul, string nilai)
        {
            sqlconn.Open();
            SqlCommand sqlUpdate = new SqlCommand("Update tb_nilai set nim = '" + nim + "',id_matkul = '" + id_matkul + "',nilai = '" + nilai + "' where id_nilai = '" + id_nilai + "'", sqlconn);
            sqlUpdate.ExecuteNonQuery();
            sqlconn.Close();
        }
        [WebMethod]
        public void HapusNilai(string id_nilai)
        {
            sqlconn.Open();
            SqlCommand sqlDelete = new SqlCommand("Delete from tb_nilai where id_nilai = '" + id_nilai + "'", sqlconn);
            sqlDelete.ExecuteNonQuery();
            sqlconn.Close();
        }
        }

        }
