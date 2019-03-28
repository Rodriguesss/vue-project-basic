<template>
  <div style="display: flex;">
    <h1>{{titulo}}</h1>
    <div class="voltar">
      <button v-show="btnVoltar" class="btn btn-voltar" @click="voltar()">Voltar</button>
      <slot></slot>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    titulo: String,
    btnVoltar: Boolean
  },
  methods: {
      voltar(){
          this.$router.back();
      }
  }
};
</script>

<style scoped>
.voltar {
  width: 50%;
  position: absolute;
  margin-top: 15px;
}
.btn-voltar {
  float: right;
  background-color: rgb(185, 174, 174);
}
.btn-voltar:hover {
  background-color: rgb(54, 74, 187);
  text-shadow: 1px 1px 1px #000;
  border-bottom: 2px solid #000;
}
</style>