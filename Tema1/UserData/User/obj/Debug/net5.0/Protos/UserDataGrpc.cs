// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user_data.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace User {
  public static partial class UserData
  {
    static readonly string __ServiceName = "UserData";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::User.SendUserData> __Marshaller_SendUserData = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::User.SendUserData.Parser));
    static readonly grpc::Marshaller<global::User.Reply> __Marshaller_Reply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::User.Reply.Parser));

    static readonly grpc::Method<global::User.SendUserData, global::User.Reply> __Method_GetUserData = new grpc::Method<global::User.SendUserData, global::User.Reply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUserData",
        __Marshaller_SendUserData,
        __Marshaller_Reply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::User.UserDataReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for UserData</summary>
    public partial class UserDataClient : grpc::ClientBase<UserDataClient>
    {
      /// <summary>Creates a new client for UserData</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public UserDataClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for UserData that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public UserDataClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected UserDataClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected UserDataClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::User.Reply GetUserData(global::User.SendUserData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetUserData(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::User.Reply GetUserData(global::User.SendUserData request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetUserData, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::User.Reply> GetUserDataAsync(global::User.SendUserData request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetUserDataAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::User.Reply> GetUserDataAsync(global::User.SendUserData request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetUserData, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override UserDataClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UserDataClient(configuration);
      }
    }

  }
}
#endregion
