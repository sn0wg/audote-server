namespace Audote.Server.Infrastructure.Repository.Animals.Constants
{
    internal class AnimalQueryConstants
    {
        internal const string SELECT_QUERY = @"
            SELECT
                a.*,
                p.*
            FROM Animal a LEFT JOIN Picture p ON a.id = p.animalId
            /**where**/
        ";

        internal const string INSERT_QUERY = @"
            INSERT INTO Animal (Name, Age, Kind, Gender, Active, Description, City, State) 
            VALUES (@Name, @Age, @Kind, @Gender, @Active, @Description, @City, @State)";

        internal const string UPDATE_QUERY = @"
            UPDATE Animal
            /**set**/
            /**where**/
        ";

        internal const string DELETE_QUERY = @"
            DELETE FROM Animal a
            /**where**/
        ";

        internal const string AGE_GTE_FILTER = "a.Age >= @MinAge";
        internal const string AGE_LTE_FILTER = "a.Age <= @MaxAge";
        internal const string KIND_IN_FILTER = "a.Kind IN @Kinds";
        internal const string GENDER_IN_FILTER = "a.Gender IN @Genders";
        internal const string CITY_EQ_FILTER = "a.City = @City";
        internal const string STATE_EQ_FILTER = "a.State = @State";
        internal const string ID_EQ_FILTER = "a.Id = @Id";
        internal const string ACTIVE_EQ_FILTER = "a.Active = @Active";

        internal const string NAME_SET_FIELD = "Name = @Name";
        internal const string AGE_SET_FIELD = "Age = @Age";
        internal const string KIND_SET_FIELD = "Kind = @Kind";
        internal const string GENDER_SET_FIELD = "Gender = @Gender";
        internal const string ACTIVE_SET_FIELD = "Active = @Active";
        internal const string DESCRIPTION_SET_FIELD = "Description = @Description";
        internal const string CITY_SET_FIELD = "City = @City";
        internal const string STATE_SET_FIELD = "State = @State";
    }
}
