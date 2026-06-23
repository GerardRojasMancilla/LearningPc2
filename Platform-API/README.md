# 🚀 Mi Plataforma de Favoritos - PC2

Este proyecto implementa un Bounded Context de Noticias (`News`) utilizando los principios de **Domain-Driven Design (DDD)** y arquitectura limpia en .NET.

## 🧠 Conceptos de Domain-Driven Design (DDD) Implementados

### ¿Qué es un Value Object (Objeto de Valor)?
Un **Value Object** es un objeto que describe una característica o concepto del negocio pero **carece de una identidad única (ID)** en la base de datos. A diferencia de las Entidades o Agregados, no nos importa "quién" es el objeto, sino **"qué valor"** contiene.

#### 🌟 Características Clave:
1. **Inmutabilidad:** Sus propiedades son de solo lectura (`private set` o C# `record`). Una vez creado, su valor no se puede alterar en el camino.
2. **Igualdad por Valor:** Dos instancias son consideradas idénticas si sus datos internos son exactamente iguales.
3. **Autovalidación (Blindaje de Dominio):** El objeto contiene las reglas de gitnegocio en su constructor. Si se intenta crear con datos inválidos (vacíos o que superen el límite de caracteres), el objeto lanza una excepción inmediatamente, impidiendo que la información corrupta se propague por la aplicación o llegue a la base de datos MySQL.

#### Commands; la Regla de Oro del Nombramiento:
El trabajo de un Command es empaquetar los datos necesarios para realizar una acción.
Siglas: Acción(Create/Register/Update/Cancel/Delete) + NombreDeLaEntidad + Command
**EJEM: UpdateProductCommand, CancelOrderCommand, DeleteUserCommand**

#### Aggregates: 
Un Aggregate es una entidad que tiene una identidad única **(un Id)** y que 
encapsula un conjunto de objetos (Value Objects)

el nombre de los archivos es con la Entidad que se busca. 
Ejem: Student, FavoriteSource, Course (se usa lenguaje obicuo)
