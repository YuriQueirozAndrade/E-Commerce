import Layout from "@pages/layouts/MainLayout.jsx";
import Card from "@components/productCard/ProductCard.jsx";
import Modal from "@components/modal/Modal.jsx";
import "@pages/home/home.css";
export default function Home()
{
  return (
  <Layout>
    <main className="mainHome">
      <Card />
    </main>
  </Layout>
  )
}
