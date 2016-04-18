﻿using Newtonsoft.Json.Linq;

namespace HexHelper.JsonApi.HexApi
{
    public sealed class DraftPackMessage : MessageBase
    {
        public DraftPackMessage( JObject aJson, string aUser ) : base( MessageType.DraftPack, aUser, true, aJson )
        {
        }

        protected override void Parse( JObject aJson )
        {
        }
    }
}