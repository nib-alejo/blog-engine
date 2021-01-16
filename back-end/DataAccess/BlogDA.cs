using Common.Entities;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess
{
    public class BlogDA : CommonDA, IBlogDA
    {
        public void Insert(Blog[] blogList)
        {
            SqlParameter[] parameterList = {
                new SqlParameter { ParameterName = "@blogList", DbType = DbType.String, Value = JsonConvert.SerializeObject(blogList) }
            };

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("blg.InsertBlog", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(parameterList);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void Update(Blog[] blogList)
        {
            SqlParameter[] parameterList = {
                new SqlParameter { ParameterName = "@blogList", DbType = DbType.String, Value = JsonConvert.SerializeObject(blogList) }
            };

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("blg.UpdateBlog", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(parameterList);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public void DeleteById(Guid id)
        {
            SqlParameter[] parameterList = {
                new SqlParameter { ParameterName = "@id", DbType = DbType.Guid, Value = id }
            };

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("blg.DeleteBlogById", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(parameterList);
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public Blog GetById(Guid id)
        {
            Blog blog = null;

            SqlParameter[] parameterList = {
                new SqlParameter { ParameterName = "@id", DbType = DbType.Guid, Value = id }
            };

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("blg.GetBlogById", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(parameterList);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            string json = Convert.ToString(sqlDataReader[0]);

                            if (!string.IsNullOrEmpty(json))
                            {
                                blog = JsonConvert.DeserializeObject<Blog>(json);
                            }
                        }
                    }
                }
            }

            return blog;
        }

        public Blog[] GetByState(Guid stateId)
        {
            Blog[] blogList = null;

            SqlParameter[] parameterList = {
                new SqlParameter { ParameterName = "@stateId", DbType = DbType.Guid, Value = stateId }
            };

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("blg.GetBlogByState", sqlConnection))
                {
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(parameterList);

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            string json = Convert.ToString(sqlDataReader[0]);

                            if (!string.IsNullOrEmpty(json))
                            {
                                blogList = JsonConvert.DeserializeObject<List<Blog>>(json).ToArray();
                            }
                        }
                    }
                }
            }

            return blogList;
        }
    }
}
