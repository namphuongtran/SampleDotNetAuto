namespace ABM.Common
{
    public enum ImageTypeConfig
    {
        Image   = 1,
        Partner = 2,
        Article = 4        
    }

    public enum UserSettingConfig
    {
        Menu            = 3,
        IsSettingMenu   = 5
    }

    public enum ApplicationsOnSystem
    {
        Booking  = 1,
        HDCN     = 2,
        ThucChay = 3
    }

    public enum GroupUserConfig
    {
        Group = 1,
        User  = 2
    }

    public enum StatusConfig
    {
        NotActive   = 1,
        Active      = 2,        
        Focus       = 4,        
        Top         = 8        
    }

    public enum TypeOfReport
    {
        Product     = 1,
        Website     = 2,
        Contract    = 3,
        Departments = 4,
        Parts       = 5,
        Group       = 6,
        Staff       = 7
    }

    public enum ReportConfig
    {
        Sum       = 0,
        Level1    = 1,
        Level2    = 2,
        Level3    = 3,        
        
        Detail    = 1,
        Synthesis = 2,
        Label     = 3,
        Company   = 4,
        Other     = 5,        
        System    = 6
    }

    public enum ModuleConfig
    {        
        System = 1
    }
}
