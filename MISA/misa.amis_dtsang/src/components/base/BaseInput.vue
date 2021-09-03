<template>
    <div class="input-wrapper">
        <input type="text" placeholder="Tìm theo mã, tên nhân viên" v-model="value">
        <div class=" icon30 icon-cancel" :class="{showCancel: isShow}" @click="cancelInputValue"></div>
        <div class=" icon30 icon-search" ></div>
    </div>
</template> 

<script>
export default {
    name: "Input",
    components: {},
    props: {
      keySearch:{
          type: String,
      },  
    },
    data(){
        return{
            value: "",
            isShow : false,
        }
    },
    watch: {
        /**
         * Lắng nghe sự thay đổi giá trị của value
         * Author: DTSang(02/09)
         */
        value: function(){
            this.$emit("keySearchChange", this.value)
            if(this.value !== ""){
                this.isShow = true;
            } else {
                this.isShow = false;
            }
        },
        keySearch: function() {
            this.value = this.keySearch;
        }
    },
    methods: {
        cancelInputValue(){
            this.value = "";
        }
    }
}
</script>

<style scoped>
.input-wrapper {
    height: 100%;
    width: 300px;
    padding: 0 10px 0 10px;
    border: 1px solid #d1d0d0;
    border-radius: 4px;
    display: flex;
}
input{
    width: 100%;
    outline: none;
    border: none;
}
input:focus {
    border-color: #35bf22;
}
::placeholder{
    color: #d1d0d0;
    font-family: Misa-Italic;
}
.icon30{
    width: 30px;
    height: 30px;
    display: flex;
}
.icon-search{
    background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -87px -26px;
}
.icon-cancel{
    display: none;
    background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -74px -303px;
}
.showCancel{
    display: block !important;
}
</style>