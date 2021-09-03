<template>
<!-- <div style=" width: 100%; height: 100%; display:flex; justify-content: center; align-items: center"> -->
  <div class="modal-confirm" :class="{'show-popup': this.isShow}">
    <div class="modal-content">
      <div class="content-confirm">
        <div class="title-popup flex">
          <div class="img-confirm"></div>
          <div class="text-confirm">
            Bạn có chắc chắn muốn xóa Nhân viên có mã nhân viên là {{this.employeeDelCode}} không?
          </div>
        </div>
        <div class="btn-popup flex">
          <div class="btn-popup-left">
              <Button typeBtn="no-comfirm" textBtn="Không" @btnOnclick="btnPopUpOnclick" />
          </div>
          <div class="btn-popup-right">
              <Button typeBtn="comfirm" textBtn="Có" @btnOnclick="btnPopUpOnclick" />
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- </div> -->
</template>

<script>
import Button from './BaseButton.vue'
export default {
  name: "PopUpConfirm",
  components: {Button},
  data() {
    return {
      isShow: false,
      employeeDelCode: "",
    }
  },
  methods: {
    /**
     * sự kiện open popup
     * Author: DTSang(31/08)
     */
    openPopupDelete(employeeCode)
    {
      this.employeeDelCode = employeeCode
      this.isShow = true;
    },
    /**
     * Bắt sự kiện khi click vào 1 trong các nút của pop up
     * Author: DTSang(31/08)
     */
    btnPopUpOnclick(type){
        if(type == "no-comfirm"){
          this.closePopupDelete();
        } else if(type == "comfirm"){
          this.confirm();
        }
    },
    /**
     * Sự kiện đóng popup
     * Author: DTSang(31/08)
     */
    closePopupDelete()
    {
      this.isShow = false;
      this.$emit("closePopUpDelete")
    },
    /**
     * Thực hiện cất nhân viên
     * Author: DTSang(31/08)
     */
    confirm()
    {
      this.$emit("comfirm");
      this.closePopupDelete();
    }
  },
};
</script>

<style scoped>
.modal-confirm {
  display: none;
  position: fixed;
  left:35%;
  top: 35%;
  width:546px;
  height: 250px;
  overflow: auto;
  background-color: rgb(0, 0, 0);
  background-color: rgba(0, 0, 0, 0.4);
  z-index:9;
}

.show-popup{
    display: block !important;
}
.modal-content {
  background-color: #fefefe;
  margin: auto;
  border: 1px solid #888;
  border-radius: 8px;
  width: 100%;
  height: 100%;
  position: relative;
}
.text-confirm{
  text-align: left;
}
.content-confirm {
  height: 100%;
  margin: 32px;
}
.title-popup
{
  height: 60%;
  border-bottom: 1px solid gray;
  display:flex;
  justify-content: center;
  align-items: center;
  font-family: Misa-Regular;
  font-size: 18px;
  padding-left: 30px
}
.btn-popup {
    height: 40%;
    display:flex;
    justify-content: space-between;
    align-items: center;
    padding: 8%;
}
.img-confirm
{
    background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -598px -463px;
    width: 48px;
    height: 48px;
    margin-top: 6px;
    margin-left: 2px;
    margin-right: 10px;
}
</style>