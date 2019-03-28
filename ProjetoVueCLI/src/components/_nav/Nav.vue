<template>
    <div class="barraTopo">
        <nav class="marginPrincipal">
            <router-link to="/professores" class="link">Professores</router-link>
            <router-link to="/alunosall" class="link">Alunos</router-link>
            <router-link to="/sobre" class="link">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default { }
</script>

<style scoped>
.barraTopo{
    background-color: rgb(255, 247, 247);
}
nav {
    padding: 20px 20px 20px 0px;
}
nav a{
    padding: 10px;
    text-decoration: none;
    background-color:#eee;
    border-radius: 5%;
    color: rgb(0, 0, 0);
    font-weight: bold;
    margin-right: 15px;
    font-size: 1.3em;
}
nav .router-link-active{
    background-color: rgb(255, 255, 255)
}
.link:hover{
    background-color: rgb(100, 197, 214);
}
</style>