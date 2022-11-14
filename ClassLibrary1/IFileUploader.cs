using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UploadFile
{
    public class main
    {
        //示範Uploader的使用方式
        public void example(HttpPostedFileBase file)
        {
            //上傳首頁檔案
            IFileUploader indexUploader = new IndexUploader();
            indexUploader.UploadFile(file);

            //上傳個人頁面檔案
            IFileUploader profilePageUploader = new ProfilePageUploader();
            profilePageUploader.UploadFile(file);
        }
    }

    public abstract class IFileUploader
    {
        //實作各分頁不同的檔案驗證方式
        protected abstract bool IsFileLegalToUpload(HttpPostedFileBase file);

        //實作儲存檔案的方式，考慮到影片/圖片/文件檔等類型可能會儲存在不同的table或硬碟空間中，因此將實際上傳方式作為抽象方法
        protected abstract void SaveFile(HttpPostedFileBase file);

        //呼叫此方法，並且將欲上傳的檔案作為參數傳入，如果檔案成功上傳，return true，否則return false
        public bool UploadFile(HttpPostedFileBase file)
        {
                if (IsFileLegalToUpload(file))
                {
                    SaveFile(file);
                    return true;
                }
                else
                {
                    return false;
                }
        }
    }

    public class IndexUploader : IFileUploader
    {
        protected override bool IsFileLegalToUpload(HttpPostedFileBase file)
        {
            //做一些Index專屬驗證，通過的話return true
            return true;
        }
        protected override void SaveFile(HttpPostedFileBase file)
        {
            try
            {
                //這裡將檔案儲存到指定的硬碟空間或資料庫table中
            }
            catch
            {
                Exception e = new Exception();
                throw new Exception(e.ToString());
            }
        }
    }

    public class ProfilePageUploader : IFileUploader
    {
        protected override bool IsFileLegalToUpload(HttpPostedFileBase file)
        {
            //做一些ProfilePage專屬驗證，通過的話return true
            return true;
        }
        protected override void SaveFile(HttpPostedFileBase file)
        {
            try
            {
                //這裡將檔案儲存到指定的硬碟空間或資料庫table中
            }
            catch
            {
                Exception e = new Exception();
                throw new Exception(e.ToString());
            }
        }
    }
}
