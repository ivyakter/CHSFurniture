using System;
//using System.Windows.Forms;
//using GsmComm.GsmCommunication;
//using GsmComm.PduConverter;
using System.Data;

public class MessageGateway
{
    DAL myDal = new DAL();
    private string Recipient;
    private string TechMobile;
    private int baudRate;
    public string callId;
    public string callTypeId;
    public string custAddress;
    private string custMess;
    private string custMobile;
    public string custName;
    private string id;
    private bool omitcustid;
    private int port;
    public bool successSendMessage;
    private string time;
    private int timeout;

    public void setPort(int port)
    {
        this.port = port;
    }

    public void getPort(out int port)
    {
        port = this.port;
    }

    public void SetData(int port, int baudRate, int timeout)
    {
        this.port = port;
        this.baudRate = baudRate;
        this.timeout = timeout;
    }

    public void GetData(out int port, out int baudRate, out int timeout)
    {
        port = this.port;
        baudRate = this.baudRate;
        timeout = this.timeout;
    }

    //private bool EnterNewSettings(int port)
    //{
    //    int newPort;
    //    int newBaudRate;
    //    int newTimeout;

    //    try
    //    {
    //        newPort = port;
    //    }
    //    catch (Exception)
    //    {
    //        MessageBox.Show("Invalid port number.", "Error");
    //        return false;
    //    }

    //    try
    //    {
    //        newBaudRate = 921600;
    //    }
    //    catch (Exception)
    //    {
    //        MessageBox.Show("Invalid baud rate.");
    //        return false;
    //    }

    //    try
    //    {
    //        newTimeout = 300;
    //    }
    //    catch (Exception)
    //    {
    //        MessageBox.Show("Invalid timeout value.");
    //        return false;
    //    }

    //    SetData(newPort, newBaudRate, newTimeout);

    //    GetData(out port, out baudRate, out timeout);
    //    CommSetting.Comm_Port = port;
    //    CommSetting.Comm_BaudRate = baudRate;
    //    CommSetting.Comm_TimeOut = timeout;

    //    return true;
    //}

    public bool GetSuccessMessage()
    {
        return successSendMessage;
    }

    public void SetCustName(string custname)
    {
        custName = custname;
    }

    public void SetCallTypeId(string callTypeId)
    {
        this.callTypeId = callTypeId;
    }


    public void SetCallId(string callId)
    {
        this.callId = callId;
    }

    public void SetAddress(string address)
    {
        custAddress = address;
    }

    public void SetTechMobile(string TechMobile)
    {
        this.TechMobile = TechMobile;
    }

    public void SetParameter(string id, string time)
    {
        this.id = id;
        string date = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(time));
        string dateTime = String.Format("{0:hh:mm tt}", DateTime.Parse(time));
        this.time = date + " " + dateTime;
    }

    public void SetCustId(string id)
    {
        this.id = id;
    }

    public void SetRecipient(string rc)
    {
        Recipient = rc;
    }


    //public bool validate(int i, string smsMessage, string Recipient1)
    //{
    //    EnterNewSettings(i);

    //    Cursor.Current = Cursors.WaitCursor;
    //    CommSetting.comm = new GsmCommMain(port, baudRate, timeout);
    //    Cursor.Current = Cursors.Default;

    //    bool retry;
    //    do
    //    {
    //        retry = true;
    //        try
    //        {
    //            Cursor.Current = Cursors.WaitCursor;
    //            if (!CommSetting.comm.IsOpen())
    //                CommSetting.comm.Open();
    //            else
    //                CommSetting.comm.Close();
    //            Cursor.Current = Cursors.Default;
    //            //return false;
    //            break; //by kamrul
    //        }
    //        catch (Exception)
    //        {
    //            Cursor.Current = Cursors.Default;
    //            //MessageBox.Show("Unable to open the port.");
    //            //i = 2;
    //            return false;
    //        }
    //    } while (retry);

    //    try
    //    {
    //        SmsSubmitPdu pdu;

    //        if (smsMessage.Length <= 160)
    //        {
    //            if (!CommSetting.comm.IsOpen())
    //                CommSetting.comm.Open();
    //            pdu = new SmsSubmitPdu(smsMessage, Recipient1, ""); // "" indicate SMSC No
    //            CommSetting.comm.SendMessage(pdu);
    //        }
    //        else
    //        {
    //            string sms1 = smsMessage.Substring(0, 160);
    //            string sms2 = smsMessage.Substring(160, smsMessage.Length - 160);
    //            pdu = new SmsSubmitPdu(sms1, Recipient1, "");
    //            // "" indicate SMSC No
    //            CommSetting.comm.SendMessage(pdu);

    //            pdu = new SmsSubmitPdu(sms2, Recipient1, "");
    //            // "" indicate SMSC No
    //            CommSetting.comm.SendMessage(pdu);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        if (i == 21)
    //            //MessageBox.Show(ex.Message);
    //            //if(CommSetting.comm.IsOpen())
    //            //CommSetting.comm.Close();
    //            return false;
    //    }

    //    Cursor.Current = Cursors.Default;
    //    return true;
    //}

    public void omitCustID(string s)
    {
        if (s.ToLower() == "service request")
        {
            omitcustid = true;
        }
        else omitcustid = false;
    }

    public void getmobile(string Mobile)
    {
        custMobile = Mobile;
    }

    public void custMessage(string custM)
    {
        custMess = custM;
    }

    public bool SendMessage()
    {

        string status = "";

        string smsMessage = "";

      

        smsMessage = "" + custMess + "";

        try
        {
            //bd.com.robi.cmp.CMPWebService service = new bd.com.robi.cmp.CMPWebService();
            //bd.com.robi.cmp.ServiceClass ReturnValues = service.SendTextMessage("bpdb", "bpdb_50272", "8801847050272", custMobile, smsMessage);
            //bd.com.robi.cmp.ServiceClass ReturnValues = service.SendTextMessage("NaNo_2", "98745699", "8801847050021", custMobile, smsMessage1);
            //status = ReturnValues.StatusText.ToString();
            //if (status == "N/A") status = "Message sending in process";
        }
        catch
        {
            status = "Sending Error";
        }
        return true;

        //}
        //else
        //{
        //    return false;
        //}


        //string smsMessage = "";

        //smsMessage = "" + custMess + "";

        //bd.com.robi.cmp.CMPWebService service = new bd.com.robi.cmp.CMPWebService();
        //bd.com.robi.cmp.ServiceClass ReturnValues = service.SendTextMessage("nano", "NANOIT@123", "8801847050021", "" + custMobile + "", "" + smsMessage + "");

        //if (ReturnValues.Status == -1)
        //{
        //    return false;
        //}
        //else 
        //{
        //    return true;
        //}

    }


    #region Nested type: ConnectedHandler

    private delegate void ConnectedHandler(bool connected);

    #endregion
}