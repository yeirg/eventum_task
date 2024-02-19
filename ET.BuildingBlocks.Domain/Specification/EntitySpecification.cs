using Ardalis.Specification;

namespace ET.BuildingBlocks.Domain.Specification;

/// <summary>
/// Представляет спецификацию для сущности, предоставляя базовые критерии выборки и условия фильтрации.
/// Этот класс является специализацией для сущностей, использующих Guid в качестве ключа.
/// </summary>
/// <typeparam name="TEntity">Тип сущности, для которой применяется спецификация. Должен быть наследником класса Entity.</typeparam>
public class EntitySpecification<TEntity> : EntitySpecification<TEntity, Guid>
    where TEntity : Entity
{
    // Здесь могут быть методы и свойства, специфичные для данной специализации
}

/// <summary>
/// Обеспечивает базовую реализацию спецификации, которая может быть применена к сущности.
/// Этот класс поддерживает кастомизацию ключа сущности.
/// </summary>
/// <typeparam name="TEntity">Тип сущности, к которой применяется спецификация.</typeparam>
/// <typeparam name="TKey">Тип ключа, используемого сущностью.</typeparam>
public class EntitySpecification<TEntity, TKey> : Specification<TEntity>
    where TEntity : Entity<TKey>
{
    // Здесь могут быть общие методы и свойства для работы со спецификациями
}