//namespace Core
//{
//    using System;

//    public class Bar
//    {
//        void Test()
//        {
//            var guid = Guid.NewGuid();

//            var gameId = new setupId();

//            FooId fooId = (FooId)gameId;
//        }   
//    }

//    public class setupId : TypedGuid
//    {
//    }

//    public class FooId : TypedGuid
//    {
//    }

//    public class TypedGuid
//    {
//        public Guid Value { get; set; }
        
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
