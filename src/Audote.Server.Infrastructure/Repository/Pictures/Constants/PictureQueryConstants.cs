namespace Audote.Server.Infrastructure.Repository.Pictures.Constants
{
    internal class PictureQueryConstants
    {
        internal const string SELECT_QUERY = @"
            SELECT
                p.*
            FROM Picture p
            /**where**/
        ";

        internal const string INSERT_QUERY = @"
            INSERT INTO Picture (Description, Path, ContentType, AnimalId) 
            VALUES (@Description, @Path, @ContentType, @AnimalId)
        ";
        internal const string DELETE_QUERY = @"
            DELETE FROM Picture
            /**where**/";

        internal const string ID_EQ_FILTER = "p.Id = @Id";
    }
}
