namespace OKU.Core.Entities
{
    public class Enums
    {
        public enum StructureDescriminator
        {
            // name / depth

            Attendee = 1,
            MaterialVerison = 2,
            Cluster = 3,
            Unit = 4,
            Item = 5
        };

        public enum ViewItemDescriminator
        {
            CodePlan = 1,
            Material = 2,
            Unit = 3,
            Item = 4
        };

        public enum TextBoxType
        {
            ShortSingleLine = 1,            
            LongSingleLine = 2,
            TextArea
        };
        
        public enum ActionOnSelection
        {
            Crud = 1,
            CrudAndActivateChildren = 2,
        };

        public enum CodePlanType
        {
            TextBox = 1,
            RadioButton = 2,
            CheckBox = 3,
            DropDown = 4
        };

        public enum Role
        {
            Admin = 1,
            MaterialModerator = 2,
            CodePlanModerator = 3,
            Coder
        };
    }
}
