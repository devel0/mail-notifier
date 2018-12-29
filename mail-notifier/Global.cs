namespace mail_notifier
{

    public class Global
    {

        static Global _Instance;
        public static Global Instance
        {
            get
            {
                if (_Instance == null) _Instance = new Global();
                return _Instance;
            }
        }

        Global()
        {
            config = Config.Load();
        }

        Config config;

        public Config Config
        {
            get
            {
                return config;
            }
        }

    }

}