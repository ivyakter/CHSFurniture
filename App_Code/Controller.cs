using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Controller
/// </summary>
public class Controller
{   
    public Controller()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
    {
        int sourceWidth = imgToResize.Width;
        int sourceHeight = imgToResize.Height;
        int destWidth = (int)size.Width;
        int destHeight = (int)size.Height;
        Bitmap b = new Bitmap(destWidth, destHeight);
        Graphics g = Graphics.FromImage(b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        g.Dispose();
        imgToResize.Dispose();
        return (System.Drawing.Image)b;
    }

    public static int RoleIdByUserName(string userName)
    {
        //DataTable dt = new dalRole().GetIdByUserName(userName);
        return Convert.ToInt32(0);
    }
    public static string RoleNameById(int id)
    {
        //DataTable dt = new dalRole().RoleNameById(id);
        return "";
    }

    public static int RegistrationNo()
    {
        DataTable dt = new dalCommon().GetRegistrationNo();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    public static int UpdateRegistrationNo()
    {
        return new dalCommon().UpdateRegistrationNo();
    }
    public static void DeleteFile(string path)
    {
        try
        {
            System.IO.File.Delete(path);
        }
        catch (Exception)
        {
        }
    }
    public static int Delete(string table, int id)
    {
        return new CommonMethod().Delete(table, id);
    }
    public static int PersonIdByUserName(string userName)
    {
        return new CommonMethod().PersonIdByUserName(userName);
    }

    public static int GetLastRoll(string criteria)
    {
        return new CommonMethod().GetLastRoll(criteria);
    }
}