
# LoginApp

**LoginApp** es una aplicación móvil desarrollada en **.NET MAUI** que implementa autenticación contra una **API REST real construida en PHP**. El proyecto sigue el patrón **MVVM** y está acompañado de pruebas **unitarias** y de **integración**.

---

## Estructura del Proyecto

```
LoginApp/             # Proyecto MAUI principal
LoginApp.Core/        # Lógica de negocio y servicios (capa desacoplada)
LoginApp.Tests/       # Pruebas unitarias e integración (con imágenes y documentación)
└── Docs/
    ├── images/       # Capturas de pantalla
    └── README_LoginApp.md
```

---

## Pruebas Automatizadas

Se implementaron 6 pruebas usando **NUnit y Moq**:

- 4 pruebas unitarias para el `LoginViewModel`
- 1 prueba de integración real hacia la API en producción
- 1 validación de comportamiento de comandos

---

## Capturas del Proceso

Las capturas se encuentran en `LoginApp.Tests/Docs/images/` y también están embebidas en el documento principal:

📄 [`README_LoginApp.md`](LoginApp.Tests/Docs/README_LoginApp.md)

---

## Documento de Entrega

- Incluye todos los pasos del desarrollo, errores encontrados y capturas.

---

## Autor

- **León Dario Builes Valencia**
- Proyecto para: *Lenguaje de Programación Avanzado 2*
- Universidad: *Corporación Universitaria Remigton*
- Año: **2025**

---

## 🔗 API de Autenticación

- **URL**: [https://app.agrodexsas.com/ApiApp/AgrdxApi.php](https://app.agrodexsas.com/ApiApp/AgrdxApi.php)
- Tipo: POST
- Campos: `method`, `usuario`, `password`

---

## Estado

> El proyecto cumple con todos los criterios de evaluación establecidos:
> - Configuración del entorno
> - Pruebas unitarias e integración
> - Documentación profesional
> - Resultados exitosos

