//namespace Core
//{
//    using System;

//    public class GameId : Guid
//    {
//    }

//    public class TypedGuid
//    {
//        protected Guid Value { get; set; }
        
//        public static implicit operator Guid(TypedGuid typedGuid)
//        {
//            return typedGuid.Value;
//        }


//        public static implicit operator TypedGuid(Guid guid)
//        {
//            return new TypedGuid { Value = guid };
//        }
//    }
//}
