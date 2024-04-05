using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GetNonPublicValueByReflection
{
    /// <summary>
    /// 取得非 Public 的資訊內容
    /// </summary>
    public class GetNonPublicValue
    {
        /// <summary>
        /// 取得非 Public 的 Property 屬性內容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">要取得資訊的物件參考</param>
        /// <param name="name">Property 屬性名稱</param>
        /// <returns></returns>
        public static object GetPropertyValue<T>(T obj, string name)
        {
            var type_ = obj.GetType();
            var pi_ = type_.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (pi_ != null)
            {
                var value_ = pi_.GetValue(obj);
                return value_;
            }
            else
            {
                // 處理找不到欄位的情況
                return null;
            };
        }

        /// <summary>
        /// 取得非 Public 的 Field 欄位內容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">要取得資訊的物件參考</param>
        /// <param name="field">Field 欄位名稱</param>
        /// <returns></returns>
        public static object GetFieldValue<T>(T obj, string field)
        {
            var type_ = obj.GetType();
            var fi_ = type_.GetField(field, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (fi_ != null)
            {
                var value_ = fi_.GetValue(obj);
                return value_;
            }
            else
            {
                // 處理找不到欄位的情況
                return null;
            };
        }




        public static List<string> GetPropertys(object obj)
        {
            var type_ = obj.GetType();
            PropertyInfo[] pia_ = type_.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<PropertyInfo> pis_ = new List<PropertyInfo>(pia_);

            List<string> fins_ = new List<string>();
            pis_.ForEach( x => fins_.Add(x.Name));
            return fins_;
        }

        public static List<object> GetObjectPropertys(object obj)
        {
            var type_ = obj.GetType();
            PropertyInfo[] pia_ = type_.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<PropertyInfo> pis_ = new List<PropertyInfo>(pia_);

            List<object> fins_ = new List<object>();
            pis_.ForEach(x => fins_.Add( NonPublic.ToName(obj, x) ));
            return fins_;
        }

        public static List<Type> GetTypePropertys(object obj)
        {
            var type_ = obj.GetType();
            PropertyInfo[] pia_ = type_.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<PropertyInfo> pis_ = new List<PropertyInfo>(pia_);

            List<Type> fins_ = new List<Type>();
            pis_.ForEach(x => fins_.Add( NonPublic.ToType(obj, x) ));
            return fins_;
        }





        public static List<string> GetFields(object obj)
        {
            var type_ = obj.GetType();
            FieldInfo[] fia_ = type_.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<FieldInfo> fis_ = new List<FieldInfo>(fia_);

            List<string> fns_ = new List<string>();
            fis_.ForEach(x =>
            {
                fns_.Add(NonPublic.ToName(obj, x));
            });
            return fns_;
        }

        public static List<object> GetObjectFields(object obj)
        {
            var type_ = obj.GetType();
            FieldInfo[] fia_ = type_.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<FieldInfo> fis_ = new List<FieldInfo>(fia_);

            List<object> fios_ = new List<object>();
            fis_.ForEach( x =>
            {
                if (x.CustomAttributes.ToList().Count == 0)
                {
                    fios_.Add(NonPublic.ToObject(obj, x));
                }
            });
            return fios_;
        }

        public static List<Type> GetTypeFields(object obj)
        {
            var type_ = obj.GetType();
            FieldInfo[] fia_ = type_.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<FieldInfo> fis_ = new List<FieldInfo>(fia_);

            List<Type> fios_ = new List<Type>();
            fis_.ForEach(x =>
            {
                if (x.CustomAttributes.ToList().Count == 0)
                {
                    fios_.Add(NonPublic.ToType(obj, x));
                }
            });
            return fios_;
        }




        public static List<NonPublic> GetNonPublicFields(object obj)
        {
            var type_ = obj.GetType();
            FieldInfo[] fia_ = type_.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<FieldInfo> fis_ = new List<FieldInfo>(fia_);

            List<NonPublic> np_ = new List<NonPublic>();
            fis_.ForEach(x =>
            {
                if (x.CustomAttributes.ToList().Count == 0)
                {

                    NonPublic y = new NonPublic
                    {
                        npName = NonPublic.ToName(obj, x),
                        npObject = NonPublic.ToObject(obj, x),
                        npType = NonPublic.ToType(obj, x)
                    };
                    np_.Add(y);
                }
            });
            return np_;
        }



        public static List<NonPublic> GetNonPublicPropertys(object obj)
        {
            var type_ = obj.GetType();
            PropertyInfo[] pia_ = type_.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            List<PropertyInfo> pis_ = new List<PropertyInfo>(pia_);

            List<NonPublic> np_ = new List<NonPublic>();
            pis_.ForEach(x =>
            {
                NonPublic y = new NonPublic
                {
                    npName   = NonPublic.ToName(obj, x),
                    npObject = NonPublic.ToObject(obj, x),
                    npType   = NonPublic.ToType(obj, x)
                };
                np_.Add(y);
            });
            return np_;
        }
    }



    /// <summary>
    /// 用來儲存物件資訊與轉換物件型別、名稱、參考等等
    /// </summary>
    public class NonPublic
    {
        public Type npType     = null;
        public string npName   = "";
        public object npObject = null;

        public static Type ToType(object obj, FieldInfo x)
        {
            return x.GetValue(obj).GetType();
        }

        public static object ToObject(object obj, FieldInfo x)
        {
            return x.GetValue(obj);
        }


        public static string ToName(object obj, FieldInfo x)
        {
            return x.Name;
        }

        public static Type ToType(object obj, PropertyInfo x)
        {
            if(x.GetValue(obj) == null)
            {
                return typeof(object);
            }
            return x.GetValue(obj).GetType();
        }

        public static object ToObject(object obj, PropertyInfo x)
        {
            return x.GetValue(obj);
        }

        public static string ToName(object obj, PropertyInfo x)
        {
            return x.Name;
        }
    }
}
