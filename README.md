# universidadEvaluacion

# USO
Si desea hacer uso de este proyecto, tendra que hacer los siguientes pasos para asi obtener la base de datos llenada automaticamente.

- Primero tendra que hacer la migracion:

  dotnet ef migrations add InitialCreate --project .\Persistence\ --startup-project .\ApiUniversidad\ --output-dir .\Data\Migrations

- Luego tendra que aplicar la migracion:
    
 dotnet ef database update --project .\Persistence\ --startup-project .\ApiUniversidad\

# PETICIONES

 Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.

    
  - Usaremos este endPoind

      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/9721ba05-5452-4953-a643-158bef3d4877)
    
  - Esta sera la respuesta


      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/85d18d83-dd25-47e8-9dfc-caa93370e530)

      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/09a72bc3-2f6b-468e-81ba-ea8c64a756bf)


Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.

  - Usaremos este endPoind

    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/12d61ea3-1dfa-4d8c-89c3-372bc9bae370)


   - Esta sera la respuesta
     
        ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/050a3358-88da-4979-bf0e-c9f54bbcf973)


Devuelve el listado de los alumnos que nacieron en `1999`.

   - Usaremos este endPoind
  
       ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/91d1235d-03fd-49e0-a642-89f250fb4044)


  - Esta sera la respuesta
  
       ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/310ef639-4794-4535-af21-88bfc3eee504)


 Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.

  - Usaremos este endPoind

    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/a07d3239-a76f-42a4-98ff-5a5a98231264)

 - Esta sera la respuesta
  
     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/ba548f36-a3d9-4d9b-ad35-3fec39d5ad61)


Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.

   - Usaremos este endPoind
  
        ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/c0b49e66-dbfd-4df0-814e-f32ddb2c3ee2)


  - Esta sera la respuesta
     
      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/f5ac9218-5e5c-4467-8c41-54f726211c27)

        

Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.

  - Usaremos este endPoind

      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/cd9e4f3e-fd1e-46ad-9288-9343b64b9d59)


   - Esta sera la respuesta 
      
        ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/671e36c0-7ae5-4d52-9236-5c19dc5ce1e2)

      

Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`

  - Usaremos este endPoind
  
    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/1a56a7ea-dba4-4e0a-b295-12695c4fb62e)

  - Esta sera la respuesta
  
       ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/ea4e05ba-d59f-4ede-b4d7-d67e74cc6b55)


Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.

  - Usaremos este metodo


    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/09d7f484-bb01-47e1-be38-a523151fc0e6) 


Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.

  - Usaremos este endPoind

     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/d58a8869-73bb-455b-855f-5248a6eb2af1)


  - Esta sera la respuesta

   ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/1fcc4b49-6518-4b51-bdc8-b1ea710fdbb8)

      

Devuelve un listado con las asignaturas que no tienen un profesor asignado.

  - Usaremos este endPoind

     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/049c4bf9-7e7d-4a0b-89c4-6380ef2cd94b)


   - Esta sera la respuesta

        ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/0f764ca6-d2ab-4ef7-98bd-2a19a1531617)



Devuelve el número total de **alumnas** que hay.

  - Usaremos este endPoind

    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/e4f7022d-aa19-47b3-86ab-e13a1cd5fb33)


  - Esta sera la respuesta

     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/59317d2c-5f57-4e15-931c-9084a30c563f)


 Calcula cuántos alumnos nacieron en `1999`.

  - Usaremos este endPoind

     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/25b6c153-5fcf-4f21-a287-71ec74be838e)


   - Esta sera la respuesta

        ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/e6b869ed-dd13-4ce9-9d8f-4bf0a12e09cf)


Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores.

  - Usaremos este endPoind

    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/2e2aed47-1ac0-4481-adff-d5a322817239)


- Esta sera la respuesta


  ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/0d310583-44fa-4c0c-a757-fa19062ef415)


 Devuelve un listado con todos los departamentos y el número de profesores que hay en cada uno de ellos. Tenga en cuenta que pueden existir departamentos que no tienen profesores asociados. Estos departamentos también tienen que aparecer en el listado.

  - Usaremos este endPoind


    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/72b1d939-7b43-406d-aa71-0719ee64c449)


- Esta sera la respuesta


  ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/3ebbc1cc-fb48-4743-b162-c1bd3d07f636)


  ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/a370a7cf-c8fe-4d05-811b-b6dfbe40fb7a)


Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno. Tenga en cuenta que pueden existir grados que no tienen asignaturas asociadas. Estos grados también tienen que aparecer en el listado. El resultado deberá estar ordenado de mayor a menor por el número de asignaturas.

  - Usaremos este endPoind

       ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/9dff712e-3b98-4a5b-a60f-84006ccab6e4)


  - Esta sera la respuesta


      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/b1451239-eb40-4e68-b1be-bfd33ad558b9)


      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/7cb8f753-2092-415d-a458-824676445d88)


 Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de `40` asignaturas asociadas.

  - Usaremos este endPoind


     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/6a9f65db-3efd-498f-8a42-07d381451bd2)


 - Esta sera la respuesta

      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/cf2c486c-028f-4078-a40f-ff98ba752942)



Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.

  - Usaremos este endPoind

          
     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/f722565c-d454-4bf7-b8d2-78dd70e4ba4e)


  - Esta sera la respuesta


    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/664179f3-0f7d-45f1-990a-395006b415c5)


Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.

  - Usaremos este endPoind

     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/ecd1ff6b-6a8a-4b3f-91ee-7246305bc949)


  - Esta sera la respuesta


    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/d54d5816-91b8-4059-b0b5-961b80ddcb49)


Devuelve todos los datos del alumno más joven.

  - Usaremos este endPoind

     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/d32a427e-4021-4d48-a51f-6defcfe5fb08)


 - Esta sera la respuesta


    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/cc0ec1f0-9362-4e55-b306-5b9926ad4978)

 
  Devuelve un listado con los departamentos que no tienen profesores asociados.

  - Usaremos este endPoind


      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/e09373e1-9b0a-45e9-909e-2ff30c22aae6)


 - Esta sera la respuesta


      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/f5bd6cca-e6e9-4c80-b890-c61e14e2781a)


 Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.

  - Usaremos este endPoind


    ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/a94765a0-8120-4b4c-9002-c502d61fb3c5)


 - Esta sera la respuesta


      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/37a51dea-c697-4022-9679-43e4642a3213)


 Devuelve un listado con las asignaturas que no tienen un profesor asignado.

   - Usaremos este endPoind

     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/85dc5461-1cdb-4261-ae25-b27466231ffe)


  - Esta sera la respuesta


     ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/54a9934d-66f7-41d3-aea0-6e3a39c5db65)


 Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.

  - Usaremos este endPoind


      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/3ab49a18-2922-4771-9cf7-ac794873ba33)


 - Esta sera la respuesta
   

      ![image](https://github.com/KevinRinc0n/universidadEvaluacion/assets/133520088/49b677a6-5ab3-48a9-bf41-d71fa0d707ef)

