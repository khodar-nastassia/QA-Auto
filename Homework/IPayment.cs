namespace Homework;

internal interface IPayment
{
    float MakePayment(float amount);
    float TopUp(float amount);
}
