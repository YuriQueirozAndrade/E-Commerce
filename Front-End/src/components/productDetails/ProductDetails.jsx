import Modal from "@components/modal/Modal.jsx";
import "@components/productDetails/details.css";
export default function Details({children})
{
  return (
    <Modal >
      <div className="product-detail">
        {children}
      </div>
    </Modal>
  )
}
