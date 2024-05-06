using MuseumManagement.Application.DTOs;
using System.Net.NetworkInformation;

namespace MuseumManagement.Application.Helpers
{
    public static class TranslatorMessages
    {
        public static class AccountMessages
        {
            public static TranslatorMessageDto Account_notfound_with_UserName(string userName) => new(nameof(Account_notfound_with_UserName), [userName]);
            public static TranslatorMessageDto Username_is_already_taken(string userName) => new(nameof(Username_is_already_taken), [userName]);
            public static string Invalid_password() => nameof(Invalid_password);
        }


        public static class ArtifactMessages
        {
            public static TranslatorMessageDto Artifact_notfound_with_id(string id)
               => new(nameof(Artifact_notfound_with_id), [id]);

            public static TranslatorMessageDto SerialNumber_is_already_taken(string serialNumber)
                => new(nameof(SerialNumber_is_already_taken), [serialNumber]);

            public static TranslatorMessageDto Requierd_field(string field)
                => new(nameof(Requierd_field), [field]);

            public static TranslatorMessageDto ImportantMaterial_not_in_Materials(string material)
                => new(nameof(ImportantMaterial_not_in_Materials), [material]);

            public static TranslatorMessageDto Most_be_unique()
                => new(nameof(Most_be_unique), []);
        }
    }
}
