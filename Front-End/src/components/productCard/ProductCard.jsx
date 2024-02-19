import Modal from "@components/modal/Modal.jsx";
import "@components/productCard/card.css";
export default function Card({children})
{
  return (
    <a className="product-link" href="/product">
      <Modal mWidth={'200px'} mHeight={'300px'}>
        {children}
      </Modal>
    </a>
  )
}

