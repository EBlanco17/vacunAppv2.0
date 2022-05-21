PGDMP                         z            vacunApp    13.4    13.4 [    )           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            *           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            +           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ,           1262    33206    vacunApp    DATABASE     i   CREATE DATABASE "vacunApp" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Spanish_Colombia.1252';
    DROP DATABASE "vacunApp";
                postgres    false                        2615    33233    administrativo    SCHEMA        CREATE SCHEMA administrativo;
    DROP SCHEMA administrativo;
                postgres    false                        2615    33207    audit    SCHEMA        CREATE SCHEMA audit;
    DROP SCHEMA audit;
                postgres    false                        2615    33220    security    SCHEMA        CREATE SCHEMA security;
    DROP SCHEMA security;
                postgres    false            �            1255    33219    if_modified_func()    FUNCTION     D  CREATE FUNCTION audit.if_modified_func() RETURNS trigger
    LANGUAGE plpgsql SECURITY DEFINER
    SET search_path TO 'pg_catalog', 'audit'
    AS $$
DECLARE
    v_old_data TEXT;
    v_new_data TEXT;
BEGIN
    if (TG_OP = 'UPDATE') then
        v_old_data := ROW(OLD.*);
        v_new_data := ROW(NEW.*);
        insert into audit.logged_actions (schema_name,table_name,user_name,action,original_data,new_data,query) 
        values (TG_TABLE_SCHEMA::TEXT,TG_TABLE_NAME::TEXT,session_user::TEXT,substring(TG_OP,1,1),v_old_data,v_new_data, current_query());
        RETURN NEW;
    elsif (TG_OP = 'DELETE') then
        v_old_data := ROW(OLD.*);
        insert into audit.logged_actions (schema_name,table_name,user_name,action,original_data,query)
        values (TG_TABLE_SCHEMA::TEXT,TG_TABLE_NAME::TEXT,session_user::TEXT,substring(TG_OP,1,1),v_old_data, current_query());
        RETURN OLD;
    elsif (TG_OP = 'INSERT') then
        v_new_data := ROW(NEW.*);
        insert into audit.logged_actions (schema_name,table_name,user_name,action,new_data,query)
        values (TG_TABLE_SCHEMA::TEXT,TG_TABLE_NAME::TEXT,session_user::TEXT,substring(TG_OP,1,1),v_new_data, current_query());
        RETURN NEW;
    else
        RAISE WARNING '[AUDIT.IF_MODIFIED_FUNC] - Other action occurred: %, at %',TG_OP,now();
        RETURN NULL;
    end if;

EXCEPTION
    WHEN data_exception THEN
        RAISE WARNING '[AUDIT.IF_MODIFIED_FUNC] - UDF ERROR [DATA EXCEPTION] - SQLSTATE: %, SQLERRM: %',SQLSTATE,SQLERRM;
        RETURN NULL;
    WHEN unique_violation THEN
        RAISE WARNING '[AUDIT.IF_MODIFIED_FUNC] - UDF ERROR [UNIQUE] - SQLSTATE: %, SQLERRM: %',SQLSTATE,SQLERRM;
        RETURN NULL;
    WHEN others THEN
        RAISE WARNING '[AUDIT.IF_MODIFIED_FUNC] - UDF ERROR [OTHER] - SQLSTATE: %, SQLERRM: %',SQLSTATE,SQLERRM;
        RETURN NULL;
END;
$$;
 (   DROP FUNCTION audit.if_modified_func();
       audit          postgres    false    5            �            1259    33335    barrios    TABLE     ~   CREATE TABLE administrativo.barrios (
    id integer NOT NULL,
    nombre text NOT NULL,
    localidad_id integer NOT NULL
);
 #   DROP TABLE administrativo.barrios;
       administrativo         heap    postgres    false    4            �            1259    33333    barrios_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.barrios_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE administrativo.barrios_id_seq;
       administrativo          postgres    false    4    219            -           0    0    barrios_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE administrativo.barrios_id_seq OWNED BY administrativo.barrios.id;
          administrativo          postgres    false    218            �            1259    33265    farmaceuticas    TABLE     a   CREATE TABLE administrativo.farmaceuticas (
    id integer NOT NULL,
    nombre text NOT NULL
);
 )   DROP TABLE administrativo.farmaceuticas;
       administrativo         heap    postgres    false    4            �            1259    33263    farmaceuticas_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.farmaceuticas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 3   DROP SEQUENCE administrativo.farmaceuticas_id_seq;
       administrativo          postgres    false    211    4            .           0    0    farmaceuticas_id_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE administrativo.farmaceuticas_id_seq OWNED BY administrativo.farmaceuticas.id;
          administrativo          postgres    false    210            �            1259    33351 
   formulario    TABLE     �   CREATE TABLE administrativo.formulario (
    id integer NOT NULL,
    usuario_id integer NOT NULL,
    eps text NOT NULL,
    localidad_id integer NOT NULL,
    barrio_id integer NOT NULL,
    direccion text NOT NULL,
    fecha_registro date NOT NULL
);
 &   DROP TABLE administrativo.formulario;
       administrativo         heap    postgres    false    4            �            1259    33349    formulario_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.formulario_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 0   DROP SEQUENCE administrativo.formulario_id_seq;
       administrativo          postgres    false    221    4            /           0    0    formulario_id_seq    SEQUENCE OWNED BY     W   ALTER SEQUENCE administrativo.formulario_id_seq OWNED BY administrativo.formulario.id;
          administrativo          postgres    false    220            �            1259    33324    localidades    TABLE     _   CREATE TABLE administrativo.localidades (
    id integer NOT NULL,
    nombre text NOT NULL
);
 '   DROP TABLE administrativo.localidades;
       administrativo         heap    postgres    false    4            �            1259    33322    localidades_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.localidades_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE administrativo.localidades_id_seq;
       administrativo          postgres    false    217    4            0           0    0    localidades_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE administrativo.localidades_id_seq OWNED BY administrativo.localidades.id;
          administrativo          postgres    false    216            �            1259    33236    solicitudes    TABLE     ,  CREATE TABLE administrativo.solicitudes (
    id integer NOT NULL,
    usuario_id integer NOT NULL,
    tipo_solicitud text NOT NULL,
    fecha_ingreso date NOT NULL,
    mensaje text NOT NULL,
    fecha_limite date NOT NULL,
    estado text NOT NULL,
    fecha_respuesta date,
    respuesta text
);
 '   DROP TABLE administrativo.solicitudes;
       administrativo         heap    postgres    false    4            �            1259    33234    solicitudes_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.solicitudes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE administrativo.solicitudes_id_seq;
       administrativo          postgres    false    207    4            1           0    0    solicitudes_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE administrativo.solicitudes_id_seq OWNED BY administrativo.solicitudes.id;
          administrativo          postgres    false    206            �            1259    33253    solicitudesadmin    TABLE     �   CREATE TABLE administrativo.solicitudesadmin (
    id integer NOT NULL,
    usuario_id integer NOT NULL,
    fecha_ingreso date NOT NULL,
    mensaje text NOT NULL
);
 ,   DROP TABLE administrativo.solicitudesadmin;
       administrativo         heap    postgres    false    4            �            1259    33251    solicitudesadmin_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.solicitudesadmin_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE administrativo.solicitudesadmin_id_seq;
       administrativo          postgres    false    4    209            2           0    0    solicitudesadmin_id_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE administrativo.solicitudesadmin_id_seq OWNED BY administrativo.solicitudesadmin.id;
          administrativo          postgres    false    208            �            1259    33285    vacunas    TABLE     g  CREATE TABLE administrativo.vacunas (
    id integer NOT NULL,
    farmaceutica_id integer NOT NULL,
    nombre text NOT NULL,
    lote text NOT NULL,
    fecha_fabricacion date NOT NULL,
    fecha_expiracion date NOT NULL,
    tiempo_proteccion integer NOT NULL,
    descripcion text NOT NULL,
    cantidad integer NOT NULL,
    no_dosis integer NOT NULL
);
 #   DROP TABLE administrativo.vacunas;
       administrativo         heap    postgres    false    4            �            1259    33283    vacunas_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.vacunas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE administrativo.vacunas_id_seq;
       administrativo          postgres    false    213    4            3           0    0    vacunas_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE administrativo.vacunas_id_seq OWNED BY administrativo.vacunas.id;
          administrativo          postgres    false    212            �            1259    33302    vacunasaplicadas    TABLE     �   CREATE TABLE administrativo.vacunasaplicadas (
    id integer NOT NULL,
    usuario_id integer NOT NULL,
    vacuna_id integer NOT NULL,
    fecha_aplicacion date NOT NULL,
    no_dosis integer NOT NULL,
    lugar_aplicacion text NOT NULL
);
 ,   DROP TABLE administrativo.vacunasaplicadas;
       administrativo         heap    postgres    false    4            �            1259    33300    vacunasaplicadas_id_seq    SEQUENCE     �   CREATE SEQUENCE administrativo.vacunasaplicadas_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 6   DROP SEQUENCE administrativo.vacunasaplicadas_id_seq;
       administrativo          postgres    false    215    4            4           0    0    vacunasaplicadas_id_seq    SEQUENCE OWNED BY     c   ALTER SEQUENCE administrativo.vacunasaplicadas_id_seq OWNED BY administrativo.vacunasaplicadas.id;
          administrativo          postgres    false    214            �            1259    33208    logged_actions    TABLE     �  CREATE TABLE audit.logged_actions (
    schema_name text NOT NULL,
    table_name text NOT NULL,
    user_name text,
    action_tstamp timestamp with time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    action text NOT NULL,
    original_data text,
    new_data text,
    query text,
    CONSTRAINT logged_actions_action_check CHECK ((action = ANY (ARRAY['I'::text, 'D'::text, 'U'::text])))
)
WITH (fillfactor='100');
 !   DROP TABLE audit.logged_actions;
       audit         heap    postgres    false    5            5           0    0    TABLE logged_actions    ACL     6   GRANT SELECT ON TABLE audit.logged_actions TO PUBLIC;
          audit          postgres    false    203            �            1259    33223    persona    TABLE     :  CREATE TABLE security.persona (
    id integer NOT NULL,
    nombres text NOT NULL,
    apellidos text NOT NULL,
    documento text NOT NULL,
    fecha_nacimiento date NOT NULL,
    genero text NOT NULL,
    telefono text NOT NULL,
    correo text NOT NULL,
    clave text NOT NULL,
    rol_id integer NOT NULL
);
    DROP TABLE security.persona;
       security         heap    postgres    false    7            �            1259    33221    persona_id_seq    SEQUENCE     �   CREATE SEQUENCE security.persona_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE security.persona_id_seq;
       security          postgres    false    205    7            6           0    0    persona_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE security.persona_id_seq OWNED BY security.persona.id;
          security          postgres    false    204            m           2604    33338 
   barrios id    DEFAULT     x   ALTER TABLE ONLY administrativo.barrios ALTER COLUMN id SET DEFAULT nextval('administrativo.barrios_id_seq'::regclass);
 A   ALTER TABLE administrativo.barrios ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    219    218    219            i           2604    33268    farmaceuticas id    DEFAULT     �   ALTER TABLE ONLY administrativo.farmaceuticas ALTER COLUMN id SET DEFAULT nextval('administrativo.farmaceuticas_id_seq'::regclass);
 G   ALTER TABLE administrativo.farmaceuticas ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    210    211    211            n           2604    33354    formulario id    DEFAULT     ~   ALTER TABLE ONLY administrativo.formulario ALTER COLUMN id SET DEFAULT nextval('administrativo.formulario_id_seq'::regclass);
 D   ALTER TABLE administrativo.formulario ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    221    220    221            l           2604    33327    localidades id    DEFAULT     �   ALTER TABLE ONLY administrativo.localidades ALTER COLUMN id SET DEFAULT nextval('administrativo.localidades_id_seq'::regclass);
 E   ALTER TABLE administrativo.localidades ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    216    217    217            g           2604    33239    solicitudes id    DEFAULT     �   ALTER TABLE ONLY administrativo.solicitudes ALTER COLUMN id SET DEFAULT nextval('administrativo.solicitudes_id_seq'::regclass);
 E   ALTER TABLE administrativo.solicitudes ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    206    207    207            h           2604    33256    solicitudesadmin id    DEFAULT     �   ALTER TABLE ONLY administrativo.solicitudesadmin ALTER COLUMN id SET DEFAULT nextval('administrativo.solicitudesadmin_id_seq'::regclass);
 J   ALTER TABLE administrativo.solicitudesadmin ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    209    208    209            j           2604    33288 
   vacunas id    DEFAULT     x   ALTER TABLE ONLY administrativo.vacunas ALTER COLUMN id SET DEFAULT nextval('administrativo.vacunas_id_seq'::regclass);
 A   ALTER TABLE administrativo.vacunas ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    212    213    213            k           2604    33305    vacunasaplicadas id    DEFAULT     �   ALTER TABLE ONLY administrativo.vacunasaplicadas ALTER COLUMN id SET DEFAULT nextval('administrativo.vacunasaplicadas_id_seq'::regclass);
 J   ALTER TABLE administrativo.vacunasaplicadas ALTER COLUMN id DROP DEFAULT;
       administrativo          postgres    false    214    215    215            f           2604    33226 
   persona id    DEFAULT     l   ALTER TABLE ONLY security.persona ALTER COLUMN id SET DEFAULT nextval('security.persona_id_seq'::regclass);
 ;   ALTER TABLE security.persona ALTER COLUMN id DROP DEFAULT;
       security          postgres    false    204    205    205            $          0    33335    barrios 
   TABLE DATA           C   COPY administrativo.barrios (id, nombre, localidad_id) FROM stdin;
    administrativo          postgres    false    219   oz                 0    33265    farmaceuticas 
   TABLE DATA           ;   COPY administrativo.farmaceuticas (id, nombre) FROM stdin;
    administrativo          postgres    false    211   �~       &          0    33351 
   formulario 
   TABLE DATA           u   COPY administrativo.formulario (id, usuario_id, eps, localidad_id, barrio_id, direccion, fecha_registro) FROM stdin;
    administrativo          postgres    false    221   *       "          0    33324    localidades 
   TABLE DATA           9   COPY administrativo.localidades (id, nombre) FROM stdin;
    administrativo          postgres    false    217   G                 0    33236    solicitudes 
   TABLE DATA           �   COPY administrativo.solicitudes (id, usuario_id, tipo_solicitud, fecha_ingreso, mensaje, fecha_limite, estado, fecha_respuesta, respuesta) FROM stdin;
    administrativo          postgres    false    207   !�                 0    33253    solicitudesadmin 
   TABLE DATA           Z   COPY administrativo.solicitudesadmin (id, usuario_id, fecha_ingreso, mensaje) FROM stdin;
    administrativo          postgres    false    209   >�                 0    33285    vacunas 
   TABLE DATA           �   COPY administrativo.vacunas (id, farmaceutica_id, nombre, lote, fecha_fabricacion, fecha_expiracion, tiempo_proteccion, descripcion, cantidad, no_dosis) FROM stdin;
    administrativo          postgres    false    213   [�                  0    33302    vacunasaplicadas 
   TABLE DATA           {   COPY administrativo.vacunasaplicadas (id, usuario_id, vacuna_id, fecha_aplicacion, no_dosis, lugar_aplicacion) FROM stdin;
    administrativo          postgres    false    215   !�                 0    33208    logged_actions 
   TABLE DATA           �   COPY audit.logged_actions (schema_name, table_name, user_name, action_tstamp, action, original_data, new_data, query) FROM stdin;
    audit          postgres    false    203   >�                 0    33223    persona 
   TABLE DATA           �   COPY security.persona (id, nombres, apellidos, documento, fecha_nacimiento, genero, telefono, correo, clave, rol_id) FROM stdin;
    security          postgres    false    205   ��       7           0    0    barrios_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('administrativo.barrios_id_seq', 1, false);
          administrativo          postgres    false    218            8           0    0    farmaceuticas_id_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('administrativo.farmaceuticas_id_seq', 1, false);
          administrativo          postgres    false    210            9           0    0    formulario_id_seq    SEQUENCE SET     H   SELECT pg_catalog.setval('administrativo.formulario_id_seq', 1, false);
          administrativo          postgres    false    220            :           0    0    localidades_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('administrativo.localidades_id_seq', 1, false);
          administrativo          postgres    false    216            ;           0    0    solicitudes_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('administrativo.solicitudes_id_seq', 1, false);
          administrativo          postgres    false    206            <           0    0    solicitudesadmin_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('administrativo.solicitudesadmin_id_seq', 1, false);
          administrativo          postgres    false    208            =           0    0    vacunas_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('administrativo.vacunas_id_seq', 14, true);
          administrativo          postgres    false    212            >           0    0    vacunasaplicadas_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('administrativo.vacunasaplicadas_id_seq', 1, false);
          administrativo          postgres    false    214            ?           0    0    persona_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('security.persona_id_seq', 1, false);
          security          postgres    false    204            �           2606    33343    barrios barrios_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY administrativo.barrios
    ADD CONSTRAINT barrios_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY administrativo.barrios DROP CONSTRAINT barrios_pkey;
       administrativo            postgres    false    219            y           2606    33273     farmaceuticas farmaceuticas_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY administrativo.farmaceuticas
    ADD CONSTRAINT farmaceuticas_pkey PRIMARY KEY (id);
 R   ALTER TABLE ONLY administrativo.farmaceuticas DROP CONSTRAINT farmaceuticas_pkey;
       administrativo            postgres    false    211            �           2606    33359    formulario formulario_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY administrativo.formulario
    ADD CONSTRAINT formulario_pkey PRIMARY KEY (id);
 L   ALTER TABLE ONLY administrativo.formulario DROP CONSTRAINT formulario_pkey;
       administrativo            postgres    false    221                       2606    33332    localidades localidades_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY administrativo.localidades
    ADD CONSTRAINT localidades_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY administrativo.localidades DROP CONSTRAINT localidades_pkey;
       administrativo            postgres    false    217            u           2606    33244    solicitudes solicitudes_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY administrativo.solicitudes
    ADD CONSTRAINT solicitudes_pkey PRIMARY KEY (id);
 N   ALTER TABLE ONLY administrativo.solicitudes DROP CONSTRAINT solicitudes_pkey;
       administrativo            postgres    false    207            w           2606    33261 &   solicitudesadmin solicitudesadmin_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY administrativo.solicitudesadmin
    ADD CONSTRAINT solicitudesadmin_pkey PRIMARY KEY (id);
 X   ALTER TABLE ONLY administrativo.solicitudesadmin DROP CONSTRAINT solicitudesadmin_pkey;
       administrativo            postgres    false    209            {           2606    33293    vacunas vacunas_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY administrativo.vacunas
    ADD CONSTRAINT vacunas_pkey PRIMARY KEY (id);
 F   ALTER TABLE ONLY administrativo.vacunas DROP CONSTRAINT vacunas_pkey;
       administrativo            postgres    false    213            }           2606    33310 &   vacunasaplicadas vacunasaplicadas_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY administrativo.vacunasaplicadas
    ADD CONSTRAINT vacunasaplicadas_pkey PRIMARY KEY (id);
 X   ALTER TABLE ONLY administrativo.vacunasaplicadas DROP CONSTRAINT vacunasaplicadas_pkey;
       administrativo            postgres    false    215            s           2606    33231    persona persona_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY security.persona
    ADD CONSTRAINT persona_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY security.persona DROP CONSTRAINT persona_pkey;
       security            postgres    false    205            o           1259    33218    logged_actions_action_idx    INDEX     U   CREATE INDEX logged_actions_action_idx ON audit.logged_actions USING btree (action);
 ,   DROP INDEX audit.logged_actions_action_idx;
       audit            postgres    false    203            p           1259    33217     logged_actions_action_tstamp_idx    INDEX     c   CREATE INDEX logged_actions_action_tstamp_idx ON audit.logged_actions USING btree (action_tstamp);
 3   DROP INDEX audit.logged_actions_action_tstamp_idx;
       audit            postgres    false    203            q           1259    33216    logged_actions_schema_table_idx    INDEX     �   CREATE INDEX logged_actions_schema_table_idx ON audit.logged_actions USING btree ((((schema_name || '.'::text) || table_name)));
 2   DROP INDEX audit.logged_actions_schema_table_idx;
       audit            postgres    false    203    203    203            �           2620    33274 +   farmaceuticas farmaceuticas_if_modified_trg    TRIGGER     �   CREATE TRIGGER farmaceuticas_if_modified_trg AFTER INSERT OR DELETE OR UPDATE ON administrativo.farmaceuticas FOR EACH ROW EXECUTE FUNCTION audit.if_modified_func();
 L   DROP TRIGGER farmaceuticas_if_modified_trg ON administrativo.farmaceuticas;
       administrativo          postgres    false    222    211            �           2620    33250 '   solicitudes solicitudes_if_modified_trg    TRIGGER     �   CREATE TRIGGER solicitudes_if_modified_trg AFTER INSERT OR DELETE OR UPDATE ON administrativo.solicitudes FOR EACH ROW EXECUTE FUNCTION audit.if_modified_func();
 H   DROP TRIGGER solicitudes_if_modified_trg ON administrativo.solicitudes;
       administrativo          postgres    false    207    222            �           2620    33262 1   solicitudesadmin solicitudesadmin_if_modified_trg    TRIGGER     �   CREATE TRIGGER solicitudesadmin_if_modified_trg AFTER INSERT OR DELETE OR UPDATE ON administrativo.solicitudesadmin FOR EACH ROW EXECUTE FUNCTION audit.if_modified_func();
 R   DROP TRIGGER solicitudesadmin_if_modified_trg ON administrativo.solicitudesadmin;
       administrativo          postgres    false    222    209            �           2620    33299    vacunas vacunas_if_modified_trg    TRIGGER     �   CREATE TRIGGER vacunas_if_modified_trg AFTER INSERT OR DELETE OR UPDATE ON administrativo.vacunas FOR EACH ROW EXECUTE FUNCTION audit.if_modified_func();
 @   DROP TRIGGER vacunas_if_modified_trg ON administrativo.vacunas;
       administrativo          postgres    false    213    222            �           2620    33321 1   vacunasaplicadas vacunasaplicadas_if_modified_trg    TRIGGER     �   CREATE TRIGGER vacunasaplicadas_if_modified_trg AFTER INSERT OR DELETE OR UPDATE ON administrativo.vacunasaplicadas FOR EACH ROW EXECUTE FUNCTION audit.if_modified_func();
 R   DROP TRIGGER vacunasaplicadas_if_modified_trg ON administrativo.vacunasaplicadas;
       administrativo          postgres    false    222    215            �           2620    33232    persona persona_if_modified_trg    TRIGGER     �   CREATE TRIGGER persona_if_modified_trg AFTER INSERT OR DELETE OR UPDATE ON security.persona FOR EACH ROW EXECUTE FUNCTION audit.if_modified_func();
 :   DROP TRIGGER persona_if_modified_trg ON security.persona;
       security          postgres    false    222    205            �           2606    33344 !   barrios barrios_localidad_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.barrios
    ADD CONSTRAINT barrios_localidad_id_fkey FOREIGN KEY (localidad_id) REFERENCES administrativo.localidades(id);
 S   ALTER TABLE ONLY administrativo.barrios DROP CONSTRAINT barrios_localidad_id_fkey;
       administrativo          postgres    false    2943    219    217            �           2606    33370 $   formulario formulario_barrio_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.formulario
    ADD CONSTRAINT formulario_barrio_id_fkey FOREIGN KEY (barrio_id) REFERENCES administrativo.barrios(id);
 V   ALTER TABLE ONLY administrativo.formulario DROP CONSTRAINT formulario_barrio_id_fkey;
       administrativo          postgres    false    219    2945    221            �           2606    33365 '   formulario formulario_localidad_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.formulario
    ADD CONSTRAINT formulario_localidad_id_fkey FOREIGN KEY (localidad_id) REFERENCES administrativo.localidades(id);
 Y   ALTER TABLE ONLY administrativo.formulario DROP CONSTRAINT formulario_localidad_id_fkey;
       administrativo          postgres    false    217    2943    221            �           2606    33360 %   formulario formulario_usuario_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.formulario
    ADD CONSTRAINT formulario_usuario_id_fkey FOREIGN KEY (usuario_id) REFERENCES security.persona(id);
 W   ALTER TABLE ONLY administrativo.formulario DROP CONSTRAINT formulario_usuario_id_fkey;
       administrativo          postgres    false    2931    221    205            �           2606    33245 '   solicitudes solicitudes_usuario_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.solicitudes
    ADD CONSTRAINT solicitudes_usuario_id_fkey FOREIGN KEY (usuario_id) REFERENCES security.persona(id);
 Y   ALTER TABLE ONLY administrativo.solicitudes DROP CONSTRAINT solicitudes_usuario_id_fkey;
       administrativo          postgres    false    205    207    2931            �           2606    33294 $   vacunas vacunas_farmaceutica_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.vacunas
    ADD CONSTRAINT vacunas_farmaceutica_id_fkey FOREIGN KEY (farmaceutica_id) REFERENCES administrativo.farmaceuticas(id);
 V   ALTER TABLE ONLY administrativo.vacunas DROP CONSTRAINT vacunas_farmaceutica_id_fkey;
       administrativo          postgres    false    211    213    2937            �           2606    33311 1   vacunasaplicadas vacunasaplicadas_usuario_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.vacunasaplicadas
    ADD CONSTRAINT vacunasaplicadas_usuario_id_fkey FOREIGN KEY (usuario_id) REFERENCES security.persona(id);
 c   ALTER TABLE ONLY administrativo.vacunasaplicadas DROP CONSTRAINT vacunasaplicadas_usuario_id_fkey;
       administrativo          postgres    false    2931    215    205            �           2606    33316 0   vacunasaplicadas vacunasaplicadas_vacuna_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY administrativo.vacunasaplicadas
    ADD CONSTRAINT vacunasaplicadas_vacuna_id_fkey FOREIGN KEY (vacuna_id) REFERENCES administrativo.vacunas(id);
 b   ALTER TABLE ONLY administrativo.vacunasaplicadas DROP CONSTRAINT vacunasaplicadas_vacuna_id_fkey;
       administrativo          postgres    false    213    215    2939            $     x�eUK��8\������� �O!�%�������J��E�ȔY���������q��ڪ�h��# ����Ի��v�5ꪁ\H5���[����=8�ΦN�쩯Lďp3��j�5$�7����R��mv�\ېq�#ħ�6
��ie�NYqG�?�71�P�=��B���x�����U<��=�1���Pb_�d���6$�!4�!�o�Cd�v����}e���I!
���`Qk��C���&f�o���\�L����iV�~SbP!�lS�Fb�]��w�}Z0�xcT�@@��A�S��q�L�=?Y��*�Z��d��l�q��&ڲ����|����g�^T�rM�u��~ F�l"��^1h4U�H?�CI�	|�d����5�:��5xA��Ň�N�D-���Pu��Kء�{�q������X�DG|��e����
P���og{(���w���N�
M���LЃf�R��"帅�5ޛ��������[�VywlI���=�0�| _��B�C�9`D'�ȩ��YcV�LmS����Xp�)5}��`%j�j����Ya��(�wi4s��,g�x[i�������n����q��hm���)����,�l6x&x����pcE���!�u���=;tc�W�Y꼹 e^t�8�"mҊRW_ME8����RH��􌩓3�G4��PM����}I�A	o��M���q#�y�Tג X�,��s��XM���k�`�M^�c�-8� �M��t���G�-������ܹW�}�������0#y��<�o�8����L�5���k~I���~0��R-�_}m���T-P��CB�
6	�Nb���٫uPq�	��A" a�.���4��Xqhta.tf�t�i�j�Ss����ch5�Wj�jYDJ����i4,��(O���KF'��9����E�&_P�>�oş��&��`�/p$������Թ��qk	���@�t���6De�X��Y~cI	��v���Rؖ��
BW���7��E�=�_UU��O�          �   x�m��
�0�ϻO�/���XO"R��˦M�B��$-��k{�����
n:r̒���N{'L��ʨ�PeMtת��@����o���AY�ч?;0C-�~�{0�i�+;��5��QpᐒTH��	�į�KD� �G7D      &      x������ � �      "   �   x�%MKR�0[ۧ�	�����i]0�vqf`�g�b�H�%�2�vS�����e8A!w����b�P��`~�]�������T��9^���zh��jڥ��^X��w�C�4�.\c�0���F�Źaΰ�Ή<R��i%�i��G�Gh�ivi�
U̧�G���y�6JT/����
�G��!����σ�����g��t�1~> �W�A�            x������ � �            x������ � �         �  x��UK��8]S��f	�2D},{v��'�2A�d1Z*�ِHIpn�e�9�/��G�;�а%�U��ի#y��A�zU�#y��4[�y��2�ˌ��tϛQrz-Ի;hvW4�R#���5��V���V��@9�8}��ǿO�z�!3R&9�ɍ�I�$��F��e�̋`��<�&���pi�+��(��Re�H0!ye��AB�ɲXg!u�fy U�|DÙ�3���c�$�|Ra(R�E��cF��U���G��3k,����-�N�����phq>��%�:L;G�l�� �;o>����5ஷʽ�����f��ri���/���n�9�%�cɒ����t�
CV��9�*#�l^�8�x��h,o����B��=o��#vC�G�V��%5��S�F#�=ע�8)�����N�pfu��q�G �ӈ�7��:pqrDT�y(+�$o`�֗xM�u)��H�,�4��a�N�T�\��x5���*Ŕ�\v\з�� 'wC��bP��E����/>��~�{_&�yr7n@7c�z�+��,Dv���h^.˞E�V�8�#��w����0hq�Z�E�Q���ȵ���͡ƛ��"~ͻ,��@��_��l���p��@�oy����Q�,�Ƌ��$�O�.D�`��
C���'�F9��q��(���4x�sڃ	&��]�XP��A\6s�u����U��0� �g������E!�������U�*��^��+���f?��S��������� ���vl�W�`�}Od��ډeb8q���fA� �}_��ث��x�i��[�ټ s��yگ�Y^P+�y�de����-�%yY9.�[T�µQeE��e$������'vo�DR��n���]�֞��T�,�*�i���MBlp��̄C���׎_ý�Fe�x��^`K�hp(_.�:�w�$�w�ז�             x������ � �            x���r�F��;O1��J� A�ȕ 	I� �N�Ֆ
"!pP�Ry�}������b��+II�e�Q�7v��w���?�Y������I���ŵ����I���X�qr��f��<n��r�ȍ��|�6�n�ՐA��xqa�8��3�u�ċ��%��WW�C���ыE�:�K��;w�g����A�ކ��D�A��\Gኬ7W�����R�\�.�P�Ûwy�,/brx���2pVP���� ��ߗx9�a�&v��T��I�8�5I���?��%�؏�0p���ҽv6~B�(r��2kQ���_gĴ��|4"0��o�P�y9�5�6����ёhFލ8���I����-�?6nt��������0H�$7G��8�S�e[\7�$$v}w��m���&^�t?�r�Ka3no��\{:=<<,��?k�ڟ�&=:9�J=:zpȒI�T���:~L�|�[�f:�lb듑6������m���U���=��z,���ln�S��7ܸѦ�/W���/�P�4[�p{�K�T//Si�,B����z��pvviM�O�6�an�#��s^^���'b[�Z�a��^�dc�*��K���^K���Qv�肩���R�G%^S*m
)Xb�D
�r����ʹ�H�����ƝFʤ�6օ,v㘚���6W/����I�%�H�5"�+�� �frxT\=7!����%����y��Z������|�A{th�Sݞ���7tΊ;~�}���b͘���6����͇Ƭn�^���qj��K��N����S-\�!�'�G�8	��&�����/?XB�aQQ�u�Oh�%���&��t?,�5?>A�9��O�n�p��M#�P�p��h:���f?@��	]CZ 	�a��(���}�&<7����O4�拟bz�a?��t�n��Ti��\;���_����/��>����꧆��T2��ĉ�.��:?����|v��%���-���w��;(ZF�Zd�E���Yy}:
���V�i�-Ay��gw�k��W�$g�ƐX�4�rg�����K��b�ri4��\��w4-���*,��
p�ݸ�m7L }���E��*�~�s�nՎB�)3�KmDb3���3�&B?��t&�n�_�t�<V�<�g�?	�BU5_�P�k�s�a�;@͉m������N;\�)]��.��zBF�%��?�ԛx�D^XUտ�/����";8JըI� |#v�o[���o@�J'��,�y����5t&W��n��t��0_'MOOu[7�t�n�P��=
z��"�1>��R���y�C��/�{;��[ސ<�a6ѧW3+���.�O<>ЖյC5�~�H/�>�H)��b6z�0��D���D�y�Rm��L��+6��$
��E'�BT̊(�����n�M��%զN^{��-8{�T��Kb�˄m^]�	9W!, �������	����󝛬�+����O�+���u��q�R�厭�˙@�ɾ�{�\E�ׂfխ�k��^��B�+8!���X�G�rN�Ƌ�[���3܁�Kg�.!� �U�X^�C)�߻#�wa��<�w�K2�ǹ�����,�;�#:�mo�w�(;=`���͍�^��d�6ͦ~����g�|R/�z�BwH�L��ա�p��t3��!)��:�VNtG~s�h~,�C�p��bxa�]����3�4,bj���V���m֔��phM��ݷҐ	{p�M�-�ʂ����!�[#�fg�Y7ϴH�(|j�3�o�Y���n�����'�Fh&�	�%��Ì`{�[s�a��n��5Z��a	�v��#����-�`S�$ۘά�6����4�+���i�m��X�ho� 2��S��1	%Ȱ���|5�G�,���X5],�٠��.Κ��ʉ`�1'!��
vz	-ȼ`G�(��b��6f�o��y�#��P"��J.)��f�F���K��g�>�R�q�v3��y��kR3�M�)�h��ը��*��X��:�l���`����6��tOɒp2 o��k��'��``�(/�8��׺iؙ�83hE2���fqCI��U���"#�,��X�`����KU���E�y� nso7��ж�6"�紐.��[��VZ�V��̋a��58G�2q��g�Բ3!ufc:�[m�����J���G����9��B��1�?��A.����¶�B�Gژ.��%mj�9+RQ���h�DM"��B4Je��3ͦ�nj���WƝ�L3:Q$�5�H�)o K�|fQ��%�-}`��i*�Ht!̆f�Cj�!���4�j}�������ᴙ��Y�b�Me�\F�n'p�@ٯ`a0��>8��Zj#���$Z�����q�bP�6��b�\FOP-�婈�`E�ؐ�dR�\�����L��b��bl^7 E�An��t�H�6`w�e'L�{y�����S| �e���d���o�X�ʛt��a�d%�ЦeS9[cv�I=.U��6�ɛ �\�N=Ā}�t2[�M�y�Sa����y.�U�´���{���85�a�\�P�0E2��}���I�+l�����!�m^�b��\PˤRX4��u��2�^YS=�r����#�d�]�����T�J{<���p�g4�1��X4����<���~���i���,�̣����Q�ol�W�\��b��_��t��â�-��hB��-݋i�P���<�u���5�b!x	M?�B~'<@a�2���̥�̳��,�l*�|��Ρ>.��U�|t���vA�VJNGT����j��

����6{Z��T&�i�����7L]B��S,I���؎u�!�Y�ǜ]-2<�B�X�,���@ɏ|�T���^�+����	uunTQ���L�.�~�̣@��?�}-�Q3[s�D�F�>����/�VS���/\:l��R9QS��7;�AZ�YIx�0�UȎ'H��V(=@P�Y�yB��t�vvШ ���)�0ք�fCu3���Y>������s�Ms1ͨ����L(������)43�-Js�ӣ@��t>�c~��h���������z���ru�D�(Xz�x����~Cg���K��F��w�j7���#�����]�p�9kJ�ϖH�!m���fH�!m���f��"6>�fH�!m���fH�!m���fH�!m���fH�!m���fH�!m���fH�!m���fH�!m���f�#m�H��$RfH�!e��RfH�!e���n�����RfH�!e��RfH�!e��RfH�!e��RfH�!e��RfH�!e��RfH�!e��RfH�!e����H����{"<C��3�<C��3�v�Fl|�<C��3�<C��3�<C��3�<C��3�<C��3�<C��3�<C��3ϾG�L��O�ș!g��rfș!g��rf��"6>rfș!g��rfș!g��rfș!g��rfș!g��rfș!g��rfș!g��rfș!g��rf�#g֖|MD��3��>C��3��>���>C��3��>C��3��>C��3��>C��3��>C��3��>C��3��>C��3��>�᳎tP}#D�Y3d͐5C�Y3d͐5����5C�Y3d͐5C�Y3d͐5C�Y3d͐5C�Y3d͐5C�Y3d͐5C�Y3d͐5C�Y3d͐5�Y��t�>"c��2fȘ!c��2fȘ�f���Ș!c��2fȘ!c��2fȘ!c��2fȘ!c��2fȘ!c��2fȘ!c��2fȘ!c��2fȘ=[�L��w�e�I�q����7�j'��dI������*M�\�J>nt�!Ņ�-�Ӄ�#^ H��hZ"�I3��[����!앍�4���r�%�;p�6��r�~ �6 !�( �X{$�����x�J��[o��(����D
�}I�h���舼�Fs0̠��NN���$"�pAľ�!5����\{ c_�0�P#t�IۍR�O���4ʽ��(7��&���\�_>�5%�����]����@��6�u�Zz���6�G�Y�*�L d  -��~>ɿ �U��uJ��Zz�՘*��FYu��Ln��Pxa>jy�k�����.�pw�Hm���M����T��
�>ŷ���]͒A
�έƕV�*���W�U����Y�����Ւdi�!4�:M�Yo&7U�A�cكD�O�L��{�!Ă�)��9TU�c.W�#|瓕�?�<�ߨ'�N��nv{._����\y��v~����M��c�ia c�D�%���rB��wTK~�e�V_�T��M��������P�E��]����mVH$F����uKVc
͍J5�}�Ur��l�}u��U*����;'�Zo5�N���RK����<��/��=~BӖ�eJ�q�_��=�яܹ��Y:T/���m�������B�ڸQ�<�N�*٭��ܼT����*�\۟�On����'�I�q"7�=���U����tp��k:g7m�w��ڑ�,��gi����/�˝��?����O *�	W(=؀2 q{�>X�`nP���ԭ�#u+�ԇ����]�澢�)'M��P{�v���rm���]Ct���v��	d�+ӏ{��]�	!�X�l��LW݃�4?�nX'#�½u�����'*.X��t�K��>�����5�>�ǉK��.�`��S�q�T��lo��ǉ���qO^��{@=Q�zWQ�^!��4�\��b�3�u�2��R�6M��=� )tA�������˼�ӆ>Qz���$�4��sO�r���<j��+7�@rG�6�yA���+<���E]_�ҫљ���#TeG�of��Q��"y��힪�Wr.X:$��υ�;�0pc� �"�L�\2��}[|ܗC�;�"n�|��gQxEu��MңN���d�܅��L@MM�rc����)��,h�@'t�8oK�~�9��0��v�0+q�}�!�ԟ_�R���2X1m����~��r�����<�~�Ԩw��u���*�b��8`eo����Oiu��{WC����wļX(����p�؍ؕ$r���ǎEʥ߰�B����{Ƣ;���v@�N��>3ׯ|7��%7s���w�F� hU_�uY�J�(<�|=7m�$�ޒ;r����$�ݬ��#�M��,}�����.��i���0-k*������	�����/9ur 5[�r��WH��
����pW��[۲��U]�SK�jnE��@8���V$Y�!�
}⎢P��7TģD+����7ߵ���5�6�������{^1��-��X1>0�UÛR}�hm��J��
.8}��E.�DU��v���䖤J37q�P���WI����޺��`y�ų=$�j���ݱ�@_C��i���&�&�?���r����;��旞�O���|n�������GT�            x������ � �     