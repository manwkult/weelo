namespace Weelo.Domain
{
    public static class Constants
    {
        // Cache

        public const string CACHE_KEY_OWNER = "Owner";
        public const string CACHE_KEY_PROPERTY = "Property";
        public const string CACHE_KEY_PROPERTY_IMAGE = "PropertyImage";
        public const string CACHE_KEY_PROPERTY_TRACE = "PropertyTrace";


        // Data
        
        public const string USERNAME = "admin";
        public const string PASSWORD = "123456";


        // Message

        public const string LOGIN_USER_LOGGED = "Usuario logueado";
        public const string LOGIN_USER_NOT_FOUND = "El usuario y/o la contraseña no son validos";

        public const string OWNER_GET_ALL_NOT_FOUND = "No se encontraron registros";
        public const string OWNER_GET_ALL_SUCCESSFULLY = "Lista de dueños";
        public const string OWNER_CREATE_ERROR = "No se pudo registrar el dueño";
        public const string OWNER_CREATE_SUCCESSFULLY = "El dueño se registro exitosamente";

        public const string PROPERTY_GET_ALL_NOT_FOUND = "No se encontraron registros";
        public const string PROPERTY_GET_ALL_SUCCESSFULLY = "Lista de propiedades";
        public const string PROPERTY_CREATE_ERROR = "No se pudo registrar la propiedad";
        public const string PROPERTY_CREATE_SUCCESSFULLY = "La propiedad se registro exitosamente";
        public const string PROPERTY_UPDATE_ERROR = "No se pudo modificar la propiedad";
        public const string PROPERTY_UPDATE_SUCCESSFULLY = "La propiedad se modifico exitosamente";
        public const string PROPERTY_CHANGE_PRICE_ERROR = "Se ha presentado un error cambiando el precio de la propiedad";
        public const string PROPERTY_CHANGE_PRICE_SUCCESSFULLY = "Se cambio el precio de la propiedad exitosamente";
        public const string PROPERTY_DELETE_ERROR = "No se pudo eliminar la propiedad";
        public const string PROPERTY_DELETE_SUCCESSFULLY = "La propiedad se elimino exitosamente";

        public const string PROPERTY_IMAGE_CREATE_ERROR = "No se pudo agregar la imagen de la propiedad";
        public const string PROPERTY_IMAGE_CREATE_SUCCESSFULLY = "La imagen de la propiedad se agrego exitosamente";
    }
}