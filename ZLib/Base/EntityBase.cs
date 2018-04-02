using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Z
{
    /// <summary>
    /// 所有实体的基础类，提供DataTable数据源转换等功能。
    /// </summary>
    public abstract class EntityBase
    {
        private DataTable _data = null;
        private DataTable GetModelStructure()
        {
            Type type = this.GetType();
            var dt = new DataTable();

            foreach (var item in type.GetProperties())
            {
                //if (item.Name == "_DataSource")
                //{
                //    continue;
                //}

                dt.Columns.Add(Data.DALUtil.GetColumnName(item), GetRealType(item.PropertyType));
            }
            return dt;

        }

        /// <summary>
        /// 将可空类型转换为实际类型
        /// </summary>
        /// <param name="type">待转换的类型</param>
        /// <returns>去除可空参数后的类型</returns>
        private Type GetRealType(Type type)
        {
            if (type == typeof(int?))
            {
                return typeof(int);
            }
            else if (type == typeof(long?))
            {
                return typeof(long);
            }
            else if (type == typeof(double?))
            {
                return typeof(double);
            }
            else if (type == typeof(float?))
            {
                return typeof(float);
            }
            else if (type == typeof(DateTime?))
            {
                return typeof(DateTime);
            }
            else if (type == typeof(bool?))
            {
                return typeof(bool);
            }
            else
            {
                return type;
            }

        }



        /// <summary>
        /// 构造函数
        /// </summary>
        protected EntityBase()
        {

        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void SetProperty(string name, object value)
        {
            Type type = this.GetType();
            var property = type.GetProperty(name);
            if (property != null)
            {
                property.SetValue(this, value, null);
            }
        }

        /// <summary>
        /// 将当前对象序列化为json字符串
        /// </summary>
        /// <returns></returns>
        public virtual string ToJsonString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// 将JSON字符串转换为实体
        /// 该功能可以同异构SOA服务传递对象
        /// </summary>
        /// <param name="json">待转换的json标准字符串</param>
        public virtual void ParseJsonString(string json)
        {


            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json, this.GetType());
            foreach (var item in this.GetType().GetProperties())
            {
                item.SetValue(this, item.GetValue(obj, null), null);
            }
        }

        /// <summary>
        /// 将实体实例化为DataRow
        /// </summary>
        /// <returns></returns>
        public virtual DataRow ToDataRow()
        {
            DataRow dr = null;
            if (_data != null)
            {
                dr = _data.NewRow();
            }
            else
            {
                _data = GetModelStructure();
                dr = _data.NewRow();
            }
            Type type = this.GetType();

            foreach (var item in type.GetProperties())
            {
                //if (item.Name == "_DataSource")
                //{
                //    continue;
                //}
                var columnname = Data.DALUtil.GetColumnName(item);


                if (dr.Table.Columns.Contains(columnname))
                {
                    var v = item.GetValue(this, null);
                    dr[columnname] = v ?? Convert.DBNull;
                }


            }



            return dr;
        }

        /// <summary>
        /// 将DataRow数据转换到实体中
        /// </summary>
        /// <param name="dr"></param>
        public virtual void ParseDataRow(DataRow dr)
        {
            Type type = this.GetType();
            var ds = dr;
            // 复制一个表结构

            this._data = ds.Table.Copy();


            foreach (var item in type.GetProperties())
            {

                var columnname = Data.DALUtil.GetColumnName(item);

                if (ds.Table.Columns.Contains(columnname))
                {

                    item.SetValue(this, Data.DALUtil.ChangeType(ds[columnname], item.PropertyType), null);

                }

            }
        }
    }
}
