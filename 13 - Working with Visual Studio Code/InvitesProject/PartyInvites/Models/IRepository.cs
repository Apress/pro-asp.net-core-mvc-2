using System.Collections.Generic;

namespace PartyInvites.Models {

    public interface IRepository {
        IEnumerable<GuestResponse> Responses {get; }

        void AddResponse(GuestResponse response);
    }
}
