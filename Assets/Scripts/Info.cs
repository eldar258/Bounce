using UnityEngine;
/// <summary>
/// Класс общих функций
/// </summary>
public static class Info
{
    /// <summary>
    /// Позволяет получить вектор силы для Rigidbody.AddForce такой, что бы не превышать заданный вектор скорости
    /// </summary>
    /// <param name="curVelocity">Текущая скорость из Rigidbody</param>
    /// <param name="velocity">Вектор ограничения скорости. Рекомендуется нормализировать вектор,
    /// а затем скалярно умножить на ограничение - это даст равномерное ограничение во все стороны,
    /// а не только по осям</param>
    /// <param name="force">Сила. Чем больше, тем быстрее достигается ограничение, но не может быть больше физических кадров в секунду.
    /// По умолчанию 1</param>
    /// <returns>Вектор силы</returns>
    public static Vector3 forceToReachVelocity(Vector3 curVelocity, Vector3 velocity, float force = 1)
    {
        float clampValue = 1 / Time.fixedDeltaTime;
        force = Mathf.Clamp(force, -clampValue, clampValue);
        Vector3 result = (velocity.normalized * Vector3.Dot(velocity, curVelocity)) / velocity.magnitude;
        return (velocity - result) * force;
    }
}
