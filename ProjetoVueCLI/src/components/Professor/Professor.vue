<template>
  <div>
    <titulo titulo="Professores" :btnVoltar="true"/>
    <table border="1px" class="professor">
      <thead>
        <th>Cod.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="professores.length" >
        <tr v-for="(professor, index) in professores" :key="index">
          <td class="colPequeno">{{professor.id}}</td>

          <router-link class="colMedio" :to="`/Alunos/${professor.id}`" tag="td" style="cursor: pointer">
              {{professor.nome}}
          </router-link>

          <td class="colPequeno">{{professor.qntAlunos}}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Professor Encontrado</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from '../_share/Titulo'

export default {
  components: {
    Titulo
  },
  data(){
    return{
      professores: [],
      alunos: []
    }
    },
    mounted() {
      this.$http
      .get('http://localhost:5000/api/aluno')
      .then((res) => res.json())
      .then(alunos =>{
        this.alunos = alunos
        this.carregarProfessores();
      })
    },
    props:{
  },
  methods:{
    pegarAlunos(){
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qntAlunos: this.alunos.filter(aluno => aluno.professor.id == professor.id)
          .length
        }
        this.professores[index] = professor;
      });
    },
    carregarProfessores(){
      this.$http
      .get('http://localhost:5000/api/professor')
      .then((res) => res.json())
      .then(professores => {
        this.professores = professores
        this.pegarAlunos();
      })
    }
  }
}
</script>

<style scoped>
.colPequeno{
  text-align: center;
  width: 15%;
}
.colMedio{
  text-align: center;
  width: 30%;
}
</style>