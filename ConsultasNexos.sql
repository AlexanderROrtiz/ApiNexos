create sequence Idlibro_seq start with 1 INCREMENT by 1 nocache NOCYCLE;

create or replace trigger al_inserta_Libro before insert on TBL_Libro for each row
begin
    select IdLibro_seq.nextval into : new.Id_Libro from dual;
end;

create sequence IdAutor_seq start with 1 INCREMENT by 1 nocache NOCYCLE;
create or replace trigger al_inserta_Autor before insert on TBL_Autor for each row
begin
    select IdAutor_seq.nextval into : new.Id_Autor from dual;
end;

alter table Tbl_Libro
 add constraint FK_libros_codigo
  foreign key (Id_Autor)
  references Tbl_Autor(Id_Autor);
  
insert into Tbl_Autor(nombrecompleto,fechanacimiento,ciudadprocedencia,correo)values ('andres','02-02-1999','belgica','andresca@hotmail.com');

select *from tbl_autor 
  
insert into Tbl_Libro(titulo,anio,genero,numeropaginas,Id_Autor)values ('libro1','1300ac','belico',220,1);

select *from Tbl_Libro

https://localhost:5500/em

scaffold-Dbcontext "user id=PRUEBAS;password=1234;data source=localhost:1521/ORCL;" Oracle.EntityframeworkCore -OutputDir Models

