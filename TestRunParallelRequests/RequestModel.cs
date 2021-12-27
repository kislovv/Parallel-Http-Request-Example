using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestRunParallelRequests;

/// <summary>
/// Контракт коллбека от курьерской службы доставки.
/// </summary>
public class CallbackModel
{
    /// <summary>
    /// Название события
    /// </summary>
    [Required]
    [JsonProperty("eventName")]
    public DeliveryEventType EventType { get; set; }

    /// <summary>
    /// ID заявки, по которой произошло событие
    /// </summary>
    [Required]
    [JsonProperty("id")]
    public string PartnerOrderId { get; set; }

    /// <summary>
    /// Время наступления события
    /// </summary>
    [JsonProperty("eventTime")]
    public long EventTime { get; set; }

    /// <summary>
    /// Номер заявки в системе банка
    /// </summary>
    [JsonProperty("clientNumber")]
    public string ClientNumber { get; set; }

    /// <summary>
    /// Идентификатор карты
    /// </summary>
    [JsonProperty("cardNumber")]
    public string CardId { get; set; }

    /// <summary>
    /// Дата и время поступления карты в региональный центр
    /// </summary>
    [JsonProperty("cardReceivedAt")]
    public DateTime CardReceivedAt { get; set; }

    /// <summary>
    /// Идентификатор назначенной встречи
    /// </summary>
    [JsonProperty("meetingId")]
    public int MeetingId { get; set; }

    /// <summary>
    /// Место назначенной встречи
    /// </summary>
    [JsonProperty("meetingPlace")]
    public string MeetingPlace { get; set; }

    /// <summary>
    /// Интервал времени для встречи
    /// </summary>
    [JsonProperty("meetingTimeInterval")]
    public string MeetingTimeInterval { get; set; }

    /// <summary>
    /// Запланированная дата
    /// </summary>
    [JsonProperty("scheduleDate")]
    public int ScheduleDate { get; set; }

    /// <summary>
    /// Имя курьера
    /// </summary>
    [JsonProperty("courierName")]
    public string CourierName { get; set; }

    /// <summary>
    /// Причина отмены
    /// </summary>
    [JsonProperty("cancelReason")]
    public string CancelReason { get; set; }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum DeliveryEventType
{
    /// <summary>
    /// Все работы по заявке окончены и документы готовы к загрузке
    /// </summary>
    [EnumMember(Value = "order.completed")]
    OrderCompleted = 1,

    /// <summary>
    /// Заявка отменена. Только супервайзер может ее вернуть в работу.
    /// </summary>
    [EnumMember(Value = "order.canceled")]
    OrderCanceled,


    /// <summary>
    /// Именная карта доставлена в региональный центр.
    /// </summary>
    [EnumMember(Value = "order.card_received")]
    CardReceived,

    /// <summary>
    /// Требуется перезвонить
    /// </summary>
    [EnumMember(Value = "order.recall_scheduled")]
    OrderRecallScheduled,

    /// <summary>
    /// Создание встречи
    /// </summary>
    [EnumMember(Value = "meeting.created")]
    MeetingCreated,

    /// <summary>
    /// Завершения встречи
    /// </summary>
    [EnumMember(Value = "meeting.completed")]
    MeetingCompleted,

    /// <summary>
    /// Встреча назначена на курьера
    /// </summary>
    [EnumMember(Value = "meeting.assigned")]
    MeetingAssigned,

    /// <summary>
    /// Отмена встречи
    /// </summary>
    [EnumMember(Value = "meeting.canceled")]
    MeetingCanceled,

    /// <summary>
    /// Перенос встречи
    /// </summary>
    [EnumMember(Value = "meeting.rescheduled")]
    MeetingRescheduled,
        
    /// <summary>
    /// Изменение адреса доставки
    /// </summary>
    [EnumMember(Value = "meeting.address_changed")]
    MeetingAddressChanged,

    /// <summary>
    /// Карта (неименная) связана с заявкой (назначена на заявку)
    /// НЕ ИЗ КУРЬЕРСКОЙ СЛУЖБЫ!
    /// </summary>
    [EnumMember(Value = "card.assigned")]
    CardAssigned
}
    