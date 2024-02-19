import Header from "@components/header/Header.jsx";
import Footer from "@components/footer/Footer.jsx";
export default function MainLayout({children})
{
  return (
  <>
    <Header />
    {children}
    <Footer />
  </>
  )
}
