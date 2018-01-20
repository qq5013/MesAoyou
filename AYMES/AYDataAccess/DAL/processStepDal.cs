﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace AYDataAccess
{
	/// <summary>
	/// 数据访问类:processStepDal
	/// </summary>
	public partial class processStepDal
	{
        public processStepDal()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return (int)DbHelperSQL.GetMaxID("stepNO", "processStep");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int stepNO)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from processStep");
            strSql.Append(" where stepNO=@stepNO ");
            SqlParameter[] parameters = {
					new SqlParameter("@stepNO", SqlDbType.Int,4)			};
            parameters[0].Value = stepNO;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(processStepModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into processStep(");
            strSql.Append("stepNO,processStepName,tag1,tag2,tag3,tag4,tag5)");
            strSql.Append(" values (");
            strSql.Append("@stepNO,@processStepName,@tag1,@tag2,@tag3,@tag4,@tag5)");
            SqlParameter[] parameters = {
					new SqlParameter("@stepNO", SqlDbType.Int,4),
					new SqlParameter("@processStepName", SqlDbType.NVarChar,50),
					new SqlParameter("@tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@tag3", SqlDbType.NVarChar,50),
					new SqlParameter("@tag4", SqlDbType.NVarChar,50),
					new SqlParameter("@tag5", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.stepNO;
            parameters[1].Value = model.processStepName;
            parameters[2].Value = model.tag1;
            parameters[3].Value = model.tag2;
            parameters[4].Value = model.tag3;
            parameters[5].Value = model.tag4;
            parameters[6].Value = model.tag5;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(processStepModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update processStep set ");
            strSql.Append("processStepName=@processStepName,");
            strSql.Append("tag1=@tag1,");
            strSql.Append("tag2=@tag2,");
            strSql.Append("tag3=@tag3,");
            strSql.Append("tag4=@tag4,");
            strSql.Append("tag5=@tag5");
            strSql.Append(" where stepNO=@stepNO ");
            SqlParameter[] parameters = {
					new SqlParameter("@processStepName", SqlDbType.NVarChar,50),
					new SqlParameter("@tag1", SqlDbType.NVarChar,50),
					new SqlParameter("@tag2", SqlDbType.NVarChar,50),
					new SqlParameter("@tag3", SqlDbType.NVarChar,50),
					new SqlParameter("@tag4", SqlDbType.NVarChar,50),
					new SqlParameter("@tag5", SqlDbType.NVarChar,50),
					new SqlParameter("@stepNO", SqlDbType.Int,4)};
            parameters[0].Value = model.processStepName;
            parameters[1].Value = model.tag1;
            parameters[2].Value = model.tag2;
            parameters[3].Value = model.tag3;
            parameters[4].Value = model.tag4;
            parameters[5].Value = model.tag5;
            parameters[6].Value = model.stepNO;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int stepNO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from processStep ");
            strSql.Append(" where stepNO=@stepNO ");
            SqlParameter[] parameters = {
					new SqlParameter("@stepNO", SqlDbType.Int,4)			};
            parameters[0].Value = stepNO;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string stepNOlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from processStep ");
            strSql.Append(" where stepNO in (" + stepNOlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public processStepModel GetModel(int stepNO)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 stepNO,processStepName,tag1,tag2,tag3,tag4,tag5 from processStep ");
            strSql.Append(" where stepNO=@stepNO ");
            SqlParameter[] parameters = {
					new SqlParameter("@stepNO", SqlDbType.Int,4)			};
            parameters[0].Value = stepNO;

            processStepModel model = new processStepModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public processStepModel DataRowToModel(DataRow row)
        {
            processStepModel model = new processStepModel();
            if (row != null)
            {
                if (row["stepNO"] != null && row["stepNO"].ToString() != "")
                {
                    model.stepNO = int.Parse(row["stepNO"].ToString());
                }
                if (row["processStepName"] != null)
                {
                    model.processStepName = row["processStepName"].ToString();
                }
                if (row["tag1"] != null)
                {
                    model.tag1 = row["tag1"].ToString();
                }
                if (row["tag2"] != null)
                {
                    model.tag2 = row["tag2"].ToString();
                }
                if (row["tag3"] != null)
                {
                    model.tag3 = row["tag3"].ToString();
                }
                if (row["tag4"] != null)
                {
                    model.tag4 = row["tag4"].ToString();
                }
                if (row["tag5"] != null)
                {
                    model.tag5 = row["tag5"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select stepNO,processStepName,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM processStep ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" stepNO,processStepName,tag1,tag2,tag3,tag4,tag5 ");
            strSql.Append(" FROM processStep ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM processStep ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.stepNO desc");
            }
            strSql.Append(")AS Row, T.*  from processStep T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "processStep";
            parameters[1].Value = "stepNO";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

