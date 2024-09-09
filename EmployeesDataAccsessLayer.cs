using Crud_with_ASP.Models;
using System.Data;
using System.Data.SqlClient;

namespace Crud_with_ASP
{
    public class EmployeesDataAccsessLayer
    {

        string cs = ConnectionString.dbcs;

        public List<Employees> getAllEmployee()
        {
            List<Employees> emplist = new List<Employees>();    

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees" ,con); 
                //we need to pass the sp name and object name here 

                cmd.CommandType = CommandType.StoredProcedure; 
                //we need to tell the method wich type of query is this so we can pass this info command type sp 
                con.Open(); // for coonection will be open 
                SqlDataReader reader = cmd.ExecuteReader();

               while(reader.Read()) 
               {
                    Employees emp = new Employees();

                    emp.Id = Convert.ToInt32(reader["ID"]);
                    emp.Name = reader["Name"].ToString() ?? "";  // ?? for not null  
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);   //for int convert 
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";

                    emplist.Add( emp );

               }
            }
            return emplist;
        }

        public Employees GetEmployeesById(int? id )
        {
            Employees emp = new Employees();  
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Employeesnew where id = @Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id" ,id);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["ID"]);
                    emp.Name = reader["Name"].ToString() ?? "";  // ?? for not null  
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);   //for int convert 
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";
                }
            }
             return emp;
        }


        public void AddEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@City", emp.City);

                con.Open();
                cmd.ExecuteNonQuery();


            }
        }

        public void UpdateEmploye(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.Id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@City", emp.City);

                con.Open();
                cmd.ExecuteNonQuery();


            }
        }

        public void DeleteEmploye(int? id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();


            }
        }



    }
}
