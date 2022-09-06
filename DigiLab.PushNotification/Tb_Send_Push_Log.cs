namespace DigiLab.PushNotification
{
    public class Tb_Send_Push_Log
    {
        public long Idx { get; set; }
        public int User_Sn { get; set; }
        public int Push_Type { get; set; }
        public string Subject { get; set; }
        public string Contents { get; set; }
        public bool IsSend { get; set; }
        public string Sendtime { get; set; }
    }
}
